// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Result codes for CefMediaRouter::CreateRoute. Should be kept in sync with
/// Chromium's media_router::mojom::RouteRequestResultCode type.
/// renumbered.
/// </summary>
public enum CefMediaRouteCreateResult
{
    UnknownError = 0,
    Ok = 1,
    TimedOut = 2,
    RouteNotFound = 3,
    SinkNotFound = 4,
    InvalidOrigin = 5,
    NoSupportedProvider = 7,
    Cancelled = 8,
    RouteAlreadyExists = 9,
    RouteAlreadyTerminated = 11,
}
