using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Chromium.Remote;
using Chromium.WebBrowser;

namespace NetDimension.NanUI
{
	public static class JSObjectExtensions
	{
		public static void RegisterJSObject(this JSObject jsObject, object clrObject)
		{
			var objectType = clrObject.GetType();

			JSObjectAttribute objectDescriber = (JSObjectAttribute)objectType.GetCustomAttributes(typeof(JSObjectAttribute), true).FirstOrDefault();

			var jsObjectName = objectType.Name;

			if (objectDescriber != null && !string.IsNullOrEmpty(objectDescriber.JSName))
			{
				jsObjectName = objectDescriber.JSName;
			}

			var thisObject = jsObject.AddObject(jsObjectName);


			RegisterJSObjectProperties(thisObject, clrObject);


		}

		private static object[] GetParametersFromCfrArguemnts(ParameterInfo[] parameters, CfrV8Value[] arguments)
		{
			var result = new List<object>();

			for (int i = 0; i < parameters.Length; i++)
			{
				var p = parameters[i];
				var clrType = p.ParameterType;
				var clrTypeCode = Type.GetTypeCode(clrType);

				if (i < arguments.Length)
				{
					var a = arguments[i];

					var value = V8ValueToClrValue(clrType, a);

					result.Add(value);
					
				}
				else
				{
					result.Add(clrType.IsValueType ? Activator.CreateInstance(clrType) : null);
				}
			}

			return result.ToArray();

		}

		private static void RegisterJSObjectProperties(JSObject thisObject, object clrObject)
		{
			var objectType = clrObject.GetType();

			var jsFunctions = objectType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(x => x.IsSpecialName == false);//.Where(x => x.GetCustomAttributes(typeof(JSFunctionAttribute), true).Length > 0);

			foreach (var func in jsFunctions)
			{
				var funcType = func.GetType();
				JSFunctionAttribute propertyDescriber = (JSFunctionAttribute)func.GetCustomAttributes(typeof(JSFunctionAttribute), true).FirstOrDefault();

				var jsPropertyName = func.Name;

				if (propertyDescriber != null && !string.IsNullOrEmpty(propertyDescriber.JSName))
				{
					jsPropertyName = propertyDescriber.JSName;
				}


				var jsFunc = thisObject.AddFunction(jsPropertyName, JSInvokeMode.DontInvoke);

				jsFunc.Execute += (_, args) =>
				{
					var funcParams = func.GetParameters();

					var clrParams = GetParametersFromCfrArguemnts(func.GetParameters(), args.Arguments);


					var returnValue = func.Invoke(clrObject, clrParams.ToArray());



					var v8ReturnValue = ClrValueToV8Value(returnValue);

					args.SetReturnValue(v8ReturnValue);
				};

			}

			var jsProperties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);//.Where(x => x.GetCustomAttributes(typeof(JSPropertyAttribute), true).Length > 0);



			foreach (var prop in jsProperties)
			{
				var propertyType = prop.GetType();
				JSPropertyAttribute propertyDescriber = (JSPropertyAttribute)prop.GetCustomAttributes(typeof(JSPropertyAttribute), true).FirstOrDefault();

				var jsPropertyName = prop.Name;

				if (propertyDescriber != null && !string.IsNullOrEmpty(propertyDescriber.JSName))
				{
					jsPropertyName = propertyDescriber.JSName;
				}

				var thisProperty = thisObject.AddDynamicProperty(jsPropertyName);


				

				if (prop.CanRead && prop.GetGetMethod()!= null && prop.GetGetMethod().IsPublic)
				{
					thisProperty.PropertyGet += (_, args) =>
					{
						args.Retval = ClrValueToV8Value(prop.GetValue(clrObject, null));
						args.SetReturnValue(true);


					};
				}
				else
				{
					thisProperty.PropertyGet += (_, args) =>
					{
						args.SetReturnValue(false);
					};
				}


				if (prop.CanWrite && prop.GetSetMethod()!= null && prop.GetSetMethod().IsPublic)
				{
					thisProperty.PropertySet += (_, args) =>
					{
						prop.SetValue(clrObject, V8ValueToClrValue(prop.PropertyType, args.Value), null);
						args.SetReturnValue(true);
					};
				}
				else
				{
					thisProperty.PropertySet += (_, args) =>
					{
						args.SetReturnValue(false);
					};
				}
			}

		}


		private static CfrV8Value ClrToV8Value(object clrValue)
		{
			var type = clrValue.GetType();

			var typeCode = Type.GetTypeCode(type);

			CfrV8Value value = null;


			switch (typeCode)
			{
				case TypeCode.Boolean:
					value = CfrV8Value.CreateBool((bool)clrValue);
					break;
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
					value = CfrV8Value.CreateInt((int)clrValue);

					break;
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					value = CfrV8Value.CreateUint((uint)clrValue);

					break;
				case TypeCode.Single:
				case TypeCode.Double:
					value = CfrV8Value.CreateDouble((double)clrValue);

					break;
				case TypeCode.Decimal:
					value = CfrV8Value.CreateDouble((double)Convert.ChangeType(clrValue, TypeCode.Double));
					break;
				case TypeCode.DateTime:
					value = CfrV8Value.CreateDate(CfrTime.FromUniversalTime((DateTime)clrValue));
					break;
				case TypeCode.Char:
				case TypeCode.String:
					value = CfrV8Value.CreateString((string)clrValue);
					break;

			}

			return value;
		}

		private static CfrV8Value ClrValueToV8Value(object clrValue)
		{

			CfrV8Value value = null;


			if (clrValue == null)
			{
				return CfrV8Value.CreateNull();
			}

			var valueType = clrValue.GetType();


			var typeCode = Type.GetTypeCode(valueType);


			if (typeCode == TypeCode.Object)
			{

				if (valueType.IsArray)
				{
					var clrArray = (Array)clrValue;
					var v8Array = new List<CfrV8Value>();
					foreach (var item in clrArray)
					{
						var itemValue = ClrValueToV8Value(item);

						if (itemValue != null)
						{
							v8Array.Add(itemValue);
						}
					}

					if (v8Array.Count > 0)
					{
						value = CfrV8Value.CreateArray(v8Array.Count);

						for (int i = 0; i < v8Array.Count; i++)
						{
							value.SetValue(i, v8Array[i]);
						}
					}
				}
				else if (valueType.IsGenericType && valueType.GetInterfaces().Count(p => p.IsGenericType && p.GetGenericTypeDefinition() == typeof(IEnumerable<>)) > 0)
				{
					var clrArray = (IEnumerable<object>)clrValue;
					var v8Array = new List<CfrV8Value>();

					foreach (var item in clrArray)
					{
						var itemValue = ClrValueToV8Value(item);

						if (itemValue != null)
						{
							v8Array.Add(itemValue);
						}
					}

					if (v8Array.Count > 0)
					{
						value = CfrV8Value.CreateArray(v8Array.Count);

						for (int i = 0; i < v8Array.Count; i++)
						{
							value.SetValue(i, v8Array[i]);
						}
					}
				}
				else
				{
					var jsObject = new JSObject(JSInvokeMode.DontInvoke);

					RegisterJSObjectProperties(jsObject, clrValue);

					value = jsObject.GetV8Value(jsObject.v8Context);

				}
			}


			if (value == null)
			{
				value = ClrToV8Value(clrValue);

				if (value == null)
				{
					value = CfrV8Value.CreateUndefined();
				}
			}



			return value;
		}




		private static object V8ValueToClrValue(Type type, CfrV8Value value)
		{
			var typeCode = Type.GetTypeCode(type);

			switch (typeCode)
			{
				case TypeCode.Boolean:
					return value.BoolValue;
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
					return value.IntValue;
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return value.UintValue;
				case TypeCode.Single:
				case TypeCode.Double:
					return value.DoubleValue;
				case TypeCode.Decimal:
					return new Decimal(value.DoubleValue);
				case TypeCode.DateTime:
					return new DateTime(value.DateValue.Year, value.DateValue.Month, value.DateValue.DayOfMonth, value.DateValue.Hour, value.DateValue.Minute, value.DateValue.Second, DateTimeKind.Utc);
				case TypeCode.Char:
					return value.StringValue.FirstOrDefault();
				case TypeCode.String:
					return value.StringValue;
			}

			return null;
		}

	}
}
