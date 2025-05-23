// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;
internal class LocalFileResourceSchemeHandlerFactory : ResourceSchemeHandlerFactory
{
    public LocalFileResourceOptions Options { get; }

    public LocalFileResourceSchemeHandlerFactory(LocalFileResourceOptions options)
        : base(options.Scheme, options.DomainName)
    {
        Options = options;
    }

    protected override CefResourceHandler GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
    {
        return new LocalFileResourceHandler(browser, frame, request, Options);
    }
}
