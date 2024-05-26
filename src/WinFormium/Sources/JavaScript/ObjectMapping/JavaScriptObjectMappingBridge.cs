// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal partial class JavaScriptObjectMappingBridge : MessageBridgeHandler
{

    public static readonly string CREATE_MAPPED_JAVASCRIPT_OBJECTS_MESSAGE = "WinFormium.CreateMappedJavascriptObjects";
    public static readonly string INITIALIZE_MAPPED_JAVASCRIPT_OBJECTS_MESSAGE = "WinFormium.InitializeMappedJavaScriptObjects";

    Dictionary<(CefFrame frame, string name), JavaScriptObject> Objects { get; } = new();

    internal bool IsObjectsInitialized { get; private set; } = false;

    public JavaScriptObjectMappingBridge(MessageBridge bridge) : base(bridge)
    {
        // local messages
        if(Side == ProcessType.Main)
        {
            RegisterMessageHandler(INITIALIZE_MAPPED_JAVASCRIPT_OBJECTS_MESSAGE, HandleInitializeJavaScriptObjectMessageOnLocal);
        }


        // remote messages
        if(Side == ProcessType.Renderer)
        {
            RegisterMessageHandler(CREATE_MAPPED_JAVASCRIPT_OBJECTS_MESSAGE, HandleCreateMappedJavaScriptObjectMessageOnRemote);
        }
    }


    private void MapObjects(CefFrame frame)
    {
        MessageBridge.SendMessageToLocal(frame, new BridgeMessage(INITIALIZE_MAPPED_JAVASCRIPT_OBJECTS_MESSAGE));
    }


    public JavaScriptObjectRegisterHandle BeginRegisterJavaScriptObject(CefFrame frame)
    {
        if (JavaScriptObjectRegisterHandle.Exists(frame))
            throw new InvalidOperationException($"This method can be only called once until {nameof(EndRegisterJavaScriptObject)} be called.");


        return new JavaScriptObjectRegisterHandle(frame);
    }

    public void EndRegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle)
    {
        if (!JavaScriptObjectRegisterHandle.Exists(handle.Frame))
            throw new InvalidOperationException($"This method can be only called once until {nameof(BeginRegisterJavaScriptObject)} be called.");

        var frame = handle.Frame;

        JavaScriptObjectRegisterHandle.Handles.Remove(handle);

        if (IsObjectsInitialized)
        {
            MapObjects(frame);
        }
    }

    public bool RegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle, string name, JavaScriptObject jsObject)
    {
        var frame = handle.Frame;

        if (!JavaScriptObjectRegisterHandle.Exists(frame))
        {
            throw new InvalidOperationException($"This method can be only called after {nameof(BeginRegisterJavaScriptObject)} be called.");
        }

        if (Objects.ContainsKey((frame, name)))
        {
            return false;
        }

        if(Objects.Keys.Any(x=>x.frame.Identifier == frame.Identifier && x.name == name))
        {
            return false;
        }

        jsObject.AssociateToFrame(frame);

        Objects.Add((frame, name), jsObject);

        return true;
    }



}
