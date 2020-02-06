using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI.RestfulService
{
    public class Route
    {
        public Method Method { get; }
        public string Path { get; }

        private Func<FormiumRequest, FormiumResponse> Action { get; }

        public Route(Method method, string routePath, Func<FormiumRequest, FormiumResponse> action)
        {
            Method = method;
            Path = routePath;
            Action = action;
        }



        public FormiumResponse Invoke(FormiumRequest request)
        {
            return Action?.Invoke(request);
        }

        public Task<FormiumResponse> InvokeAsync(FormiumRequest request)
        {
            return Task.Factory.StartNew(() => Action?.Invoke(request));
        }

        
    }
}
