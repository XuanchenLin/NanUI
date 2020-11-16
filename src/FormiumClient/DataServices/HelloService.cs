using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI.ResourceHandler;
using NetDimension.NanUI.DataServiceResource;

namespace FormiumClient.DataServices
{
    public class HelloService : DataService
    {
        //GET /hello/hi
        public ResourceResponse Hi(ResourceRequest request)
        {
            return Text("Hello world!");
        }
    }
}
