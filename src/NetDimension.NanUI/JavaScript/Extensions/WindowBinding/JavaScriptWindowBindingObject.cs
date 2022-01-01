namespace NetDimension.NanUI.JavaScript.WindowBinding;

public abstract class JavaScriptWindowBindingObject
{
    public abstract string Name { get; }
    public abstract string JavaScriptCode { get; }

    internal List<JavaScriptWindowBindingFunction> WindowBindingFunctions { get; } = new List<JavaScriptWindowBindingFunction>();

    public JavaScriptWindowBindingObject()
    {

    }


    internal protected void RegisterHandler(string functionName, Action<Formium, JavaScriptArray, JavaScriptFunctionPromise> function)
    {
        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }

    internal protected void RegisterHandler(Action<Formium, JavaScriptArray, JavaScriptFunctionPromise> function)
    {

        var functionName = function.Method.Name;
        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }

    internal protected void RegisterHandler(string functionName, Func<Formium, JavaScriptArray, JavaScriptValue> function)
    {
        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }

    internal protected void RegisterHandler(Func<Formium, JavaScriptArray, JavaScriptValue> function)
    {
        var functionName = function.Method.Name;

        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }

    internal protected void RegisterHandler(string functionName, Action<JavaScriptArray, JavaScriptFunctionPromise> function)
    {
        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }
    internal protected void RegisterHandler(Action<JavaScriptArray, JavaScriptFunctionPromise> function)
    {
        var functionName = function.Method.Name;

        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }

    internal protected void RegisterHandler(string functionName, Func<JavaScriptArray, JavaScriptValue> function)
    {
        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }
    internal protected void RegisterHandler(Func<JavaScriptArray, JavaScriptValue> function)
    {
        var functionName = function.Method.Name;

        if (WindowBindingFunctions.Any(x => x.FunctionName == functionName))
        {
            throw new ArgumentException();
        }

        WindowBindingFunctions.Add(new JavaScriptWindowBindingFunction(functionName, function));
    }



    internal JavaScriptWindowBindingHandler GetV8Handler()
    {
        return new JavaScriptWindowBindingHandler(this);
    }


}
