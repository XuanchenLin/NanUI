//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_media_route_create_result_t.
//
namespace Xilium.CefGlue
{
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
}
