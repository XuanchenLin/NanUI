// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Linq.Expressions;

namespace WinFormium.WebResource;
public sealed class DataResourceRoute
{
    public ResourceRequestMethod Method { get; }
    public string[] Path { get; }
    internal MethodInfo ActionInfo { get; }
    public JsonSerializerOptions? DefaultJsonSerializerOptions { get; } = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    internal Type BaseType => ActionInfo.DeclaringType!;

    internal bool IsAsync => ActionInfo.ReturnType == typeof(Task<IResourceResult>);

    internal DataResourceRoute(ResourceRequestMethod method, string[] path, MethodInfo action, JsonSerializerOptions? defaultJsonSerializerOptions)
    {
        Method = method;
        Path = path;
        ActionInfo = action;
        DefaultJsonSerializerOptions = defaultJsonSerializerOptions;
    }

    internal object? Execute(DataResourceContext context)
    {
        var constructor = BaseType.GetConstructors().Where(x => x.IsStatic == false).ToList();

        if (constructor.Count != 1) throw new Exception("Only one constructor is allowed");

        var paramValues = new List<object?>();


        foreach (var constructParam in constructor[0].GetParameters())
        {
            var paramName = constructParam.Name?.ToLower();
            var paramType = constructParam.ParameterType;

            object? paramValue = null;

            var services = WinFormiumApp.Current!.Services;
            if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var genericType = paramType.GetGenericArguments()[0];
                var listType = typeof(List<>);
                var newType = listType.MakeGenericType(new Type[] { genericType });
                var list = (IList?)Activator.CreateInstance(newType);

                services.GetServices(genericType).ToList().ForEach(x => list?.Add(x));

                paramValue = list;
            }
            else
            {
                paramValue = services.GetService(paramType);
            }


            if (paramValue == null)
            {
                paramValue = paramType.IsValueType ? Activator.CreateInstance(paramType) : null;
            }

            paramValues.Add(paramValue);
        }

        var service = Activator.CreateInstance(BaseType, paramValues.ToArray()) as DataResourceService;

        if (service == null) throw new NullReferenceException("Service is null");

        service.Context = context;

        var actionParams = ActionInfo.GetParameters().Select(x => Expression.Parameter(x.ParameterType, x.Name)).ToArray();

        var caller = Expression.Call(Expression.Constant(service), ActionInfo, actionParams);

        var actionDelegate = Expression.Lambda(caller, actionParams).Compile();

        var request = context.Request;
        var response = context.Response;


        paramValues = new List<object?>();

        foreach (var actionParam in ActionInfo.GetParameters())
        {
            var paramName = actionParam.Name?.ToLower();
            var paramType = actionParam.ParameterType;

            object? paramValue = null;

            if (request.QueryString?[paramName] != null)
            {
                if (paramType.IsArray || (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    var vals = request.QueryString.GetValues(paramName);

                    if (vals != null)
                    {
                        if (paramType.IsGenericType)
                        {
                            var genericType = paramType.GetGenericArguments()[0];

                            var listType = typeof(List<>);

                            var newType = listType.MakeGenericType(new Type[] { genericType });

                            var list = (IList?)Activator.CreateInstance(newType);

                            foreach (var val in vals)
                            {
                                try
                                {
                                    list?.Add(Convert.ChangeType(val, genericType));
                                }
                                catch
                                {
                                    var defaultVal = genericType.IsValueType ? Activator.CreateInstance(genericType) : null;
                                    list?.Add(defaultVal);
                                }
                            }
                            paramValue = list;
                        }
                        else
                        {
                            var array = Array.CreateInstance(paramType.GetElementType()!, vals.Length);

                            for (var i = 0; i < vals.Length; i++)
                            {
                                array.SetValue(Convert.ChangeType(vals[i], paramType.GetElementType()!), i);
                            }

                            paramValue = array;
                        }
                    }
                }
                else
                {
                    var val = request.QueryString.Get(paramName);

                    if (val != null)
                    {
                        paramValue = Convert.ChangeType(val, paramType);
                    }
                }
            }
            else if (request.FormData?[paramName] != null)
            {
                if (paramType.IsArray || (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {

                    var vals = request.FormData.GetValues(paramName);

                    if (vals != null)
                    {
                        if (paramType.IsGenericType)
                        {
                            var genericType = paramType.GetGenericArguments()[0];

                            var listType = typeof(List<>);

                            var newType = listType.MakeGenericType(new Type[] { genericType });

                            var list = (IList?)Activator.CreateInstance(newType);

                            foreach (var val in vals)
                            {
                                try
                                {
                                    list?.Add(Convert.ChangeType(val, genericType));
                                }
                                catch
                                {
                                    var defaultVal = genericType.IsValueType ? Activator.CreateInstance(genericType) : null;
                                    list?.Add(defaultVal);
                                }
                            }

                            paramValue = list;

                        }
                        else
                        {
                            var array = Array.CreateInstance(paramType.GetElementType()!, vals.Length);

                            for (var i = 0; i < vals.Length; i++)
                            {
                                array.SetValue(Convert.ChangeType(vals[i], paramType.GetElementType()!), i);
                            }

                            paramValue = array;
                        }
                    }

                }
                else
                {
                    var val = request.FormData.Get(paramName);

                    if (val != null)
                    {
                        paramValue = Convert.ChangeType(val, paramType);
                    }
                }
            }

            if (paramValue == null)
            {
                var hasJsonBodyAttribute = actionParam.GetCustomAttributes(typeof(JsonBodyAttribute), false).Length > 0;

                if (hasJsonBodyAttribute && request.IsJson && request.RawData!=null)
                {
                    paramValue = JsonSerializer.Deserialize(request.RawData, paramType, DefaultJsonSerializerOptions ?? new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true,
                    });
                }
            };



            if(paramValue == null)
            {
                paramValue = paramType.IsValueType ? Activator.CreateInstance(paramType) : null;
            }

            paramValues.Add(paramValue);
        }

        return actionDelegate.DynamicInvoke(paramValues.ToArray());

    }



}
