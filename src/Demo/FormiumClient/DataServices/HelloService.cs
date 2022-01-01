using NetDimension.NanUI.Browser.ResourceHandler;
using NetDimension.NanUI.Resource.Data;

namespace FormiumClient.DataServices;
public class HelloService : DataService
{
    //GET /hello/hi
    public ResourceResponse Hi(ResourceRequest request)
    {
        return Text("Hello world!");
    }
}