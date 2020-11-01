using System.Security.Cryptography.X509Certificates;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    internal class JavaScriptRenderSideFunction
    {
        public int Id { get; }
        public string Name { get; }
        public CefV8Context Context { get; }
        public CefV8Value Function { get; }

        public JavaScriptRenderSideFunction(CefV8Context context, CefV8Value function)
        {
            Id = function.GetHashCode();
            Name = function.GetFunctionName();
            Context = context;
            Function = function;
        }


    }


}
