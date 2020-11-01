using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    internal static class JavaScriptObjectRepository
    {
        public static HashSet<JavaScriptRenderSideFunction> RenderSideFunctions { get; } = new HashSet<JavaScriptRenderSideFunction>();

        public static ConcurrentDictionary<Tuple<int, long>, TaskCompletionSource<JavaScriptExecutionResult>> JavaScriptExecutionTasks { get; } = new ConcurrentDictionary<Tuple<int, long>, TaskCompletionSource<JavaScriptExecutionResult>>();


        public static HashSet<JavaScriptRenderSideAsyncFunction> AsyncFunctions { get; } = new HashSet<JavaScriptRenderSideAsyncFunction>();

        
    }

}
