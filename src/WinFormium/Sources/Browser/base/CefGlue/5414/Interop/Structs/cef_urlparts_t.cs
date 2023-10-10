// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_urlparts_t
{
    public cef_string_t spec;
    public cef_string_t scheme;
    public cef_string_t username;
    public cef_string_t password;
    public cef_string_t host;
    public cef_string_t port;
    public cef_string_t origin;
    public cef_string_t path;
    public cef_string_t query;
    public cef_string_t fragment;

    internal static void Clear(cef_urlparts_t* self)
    {
        libcef.string_clear(&self->spec);
        libcef.string_clear(&self->scheme);
        libcef.string_clear(&self->username);
        libcef.string_clear(&self->password);
        libcef.string_clear(&self->host);
        libcef.string_clear(&self->port);
        libcef.string_clear(&self->origin);
        libcef.string_clear(&self->path);
        libcef.string_clear(&self->query);
        libcef.string_clear(&self->fragment);
    }
}
