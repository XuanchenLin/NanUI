using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptObjectMapping;

class MapJavaScriptObjectOnBrowserSide : MessageHandlerOnBrowserSide
{
    internal HashSet<MappedObject> CachedObjects { get; } = new HashSet<MappedObject>();

    internal bool IsObjectsMapped { get; private set; } = false;

    MapJavaScriptObjectHandler MessageHandler => (MapJavaScriptObjectHandler)this.MessageHandlerWrapper;


    public MapJavaScriptObjectOnBrowserSide(MessageHandlerWrapperBase messageHandlerWrapper)
: base(messageHandlerWrapper)
    {

    }

    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame)
    {
    }

    public override void OnBeforeClose(CefBrowser browser)
    {

    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
        if (message == MapJavaScriptObjectHandler.PREMAP_OBJECTS)
        {

            IsObjectsMapped = true;

            RemapObjects();
        }
    }

    public override void OnRenderProcessTerminated(CefBrowser browser)
    {

    }

    public void RegisterJavaScriptObject(CefFrame frame, string name, JavaScriptObject obj)
    {
        if (CachedObjects.Count(x => x.Name.Equals(name)) > 0)
        {
            throw new InvalidOperationException($"The key {name} has already exists.");
        }

        obj.BindToFrame(frame, true);

        var mappedObject = new MappedObject { Name = name, Object = obj };

        CachedObjects.Add(mappedObject);


        if (IsObjectsMapped)
        {
            RemapObjects();
        }

    }

    private void RemapObjects()
    {
        CefRuntime.PostTask(CefThreadId.UI, new MapObjectsToRenderTask(Owner.GetMainFrame(), CachedObjects));
    }
}

internal sealed class MappedObject
{
    public string Name { get; set; }
    public JavaScriptObject Object { get; set; }
}
