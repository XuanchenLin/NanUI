// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;

internal class EmbeddedFileResourceSchemeHandlerFactory : ResourceSchemeHandlerFactory
{
    public EmbeddedFileResourceOptions Options { get; }


    public EmbeddedFileResourceSchemeHandlerFactory(EmbeddedFileResourceOptions options)
        : base(options.Scheme, options.DomainName)
    {
        Options = options;
    }


    protected override CefResourceHandler GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
    {
        return new EmbeddedFileResourceHandler(browser, frame, request, Options);
    }
}
