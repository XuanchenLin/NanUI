// Starting from version 75 this code is obsolete.
// Note, this implementation had been manually written very long time ago,
// and never used actively, so has some bugs. At this moment it should
// route requests to frames instead to browser (to reflect CEF 75 changes).
// If you want, you can fix and/or re-enable in build.
// Feel free to open issue if you miss this feature.


// The below classes implement support for routing aynchronous messages between
// JavaScript running in the renderer process and C++ running in the browser
// process. An application interacts with the router by passing it data from
// standard CEF C++ callbacks (OnBeforeBrowse, OnProcessMessageRecieved,
// OnContextCreated, etc). The renderer-side router supports generic JavaScript
// callback registration and execution while the browser-side router supports
// application-specific logic via one or more application-provided Handler
// instances.
//
// The renderer-side router implementation exposes a query function and a cancel
// function via the JavaScript 'window' object:
//
//    // Create and send a new query.
//    var request_id = window.cefQuery({
//        request: 'my_request',
//        persistent: false,
//        onSuccess: function(response) {},
//        onFailure: function(error_code, error_message) {}
//    });
//
//    // Optionally cancel the query.
//    window.cefQueryCancel(request_id);
//
// When |window.cefQuery| is executed the request is sent asynchronously to one
// or more C++ Handler objects registered in the browser process. Each C++
// Handler can choose to either handle or ignore the query in the
// Handler::OnQuery callback. If a Handler chooses to handle the query then it
// should execute Callback::Success when a response is available or
// Callback::Failure if an error occurs. This will result in asynchronous
// execution of the associated JavaScript callback in the renderer process. Any
// queries unhandled by C++ code in the browser process will be automatically
// canceled and the associated JavaScript onFailure callback will be executed
// with an error code of -1.
//
// Queries can be either persistent or non-persistent. If the query is
// persistent than the callbacks will remain registered until one of the
// following conditions are met:
//
// A. The query is canceled in JavaScript using the |window.cefQueryCancel|
//    function.
// B. The query is canceled in C++ code using the Callback::Failure function.
// C. The context associated with the query is released due to browser
//    destruction, navigation or renderer process termination.
//
// If the query is non-persistent then the registration will be removed after
// the JavaScript callback is executed a single time. If a query is canceled for
// a reason other than Callback::Failure being executed then the associated
// Handler's OnQueryCanceled method will be called.
//
// Some possible usage patterns include:
//
// One-time Request. Use a non-persistent query to send a JavaScript request.
//    The Handler evaluates the request and returns the response. The query is
//    then discarded.
//
// Broadcast. Use a persistent query to register as a JavaScript broadcast
//    receiver. The Handler keeps track of all registered Callbacks and executes
//    them sequentially to deliver the broadcast message.
//
// Subscription. Use a persistent query to register as a JavaScript subscription
//    receiver. The Handler initiates the subscription feed on the first request
//    and delivers responses to all registered subscribers as they become
//    available. The Handler cancels the subscription feed when there are no
//    longer any registered JavaScript receivers.
//
// Message routing occurs on a per-browser and per-context basis. Consequently,
// additional application logic can be applied by restricting which browser or
// context instances are passed into the router. If you choose to use this
// approach do so cautiously. In order for the router to function correctly any
// browser or context instance passed into a single router callback must then
// be passed into all router callbacks.
//
// There is generally no need to have multiple renderer-side routers unless you
// wish to have multiple bindings with different JavaScript function names. It
// can be useful to have multiple browser-side routers with different client-
// provided Handler instances when implementing different behaviors on a per-
// browser basis.
//
// This implementation places no formatting restrictions on payload content.
// An application may choose to exchange anything from simple formatted
// strings to serialized XML or JSON data.
//
//
// EXAMPLE USAGE
//
// 1. Define the router configuration. You can optionally specify settings
//    like the JavaScript function names. The configuration must be the same in
//    both the browser and renderer processes. If using multiple routers in the
//    same application make sure to specify unique function names for each
//    router configuration.
//
//    // Example config object showing the default values.
//    CefMessageRouterConfig config;
//    config.js_query_function = "cefQuery";
//    config.js_cancel_function = "cefQueryCancel";
//
// 2. Create an instance of CefMessageRouterBrowserSide in the browser process.
//    You might choose to make it a member of your CefClient implementation,
//    for example.
//
//    browser_side_router_ = CefMessageRouterBrowserSide::Create(config);
//
// 3. Register one or more Handlers. The Handler instances must either outlive
//    the router or be removed from the router before they're deleted.
//
//    browser_side_router_->AddHandler(my_handler);
//
// 4. Call all required CefMessageRouterBrowserSide methods from other callbacks
//    in your CefClient implementation (OnBeforeClose, etc). See the
//    CefMessageRouterBrowserSide class documentation for the complete list of
//    methods.
//
// 5. Create an instance of CefMessageRouterRendererSide in the renderer process.
//    You might choose to make it a member of your CefApp implementation, for
//    example.
//
//    renderer_side_router_ = CefMessageRouterRendererSide::Create(config);
//
// 6. Call all required CefMessageRouterRendererSide methods from other
//    callbacks in your CefRenderProcessHandler implementation
//    (OnContextCreated, etc). See the CefMessageRouterRendererSide class
//    documentation for the complete list of methods.
//
// 7. Execute the query function from JavaScript code.
//
//    window.cefQuery({request: 'my_request',
//                     persistent: false,
//                     onSuccess: function(response) { print(response); },
//                     onFailure: function(error_code, error_message) {} });
//
// 8. Handle the query in your Handler::OnQuery implementation and execute the
//    appropriate callback either immediately or asynchronously.
//
//    void MyHandler::OnQuery(int64 query_id,
//                            CefRefPtr<CefBrowser> browser,
//                            CefRefPtr<CefFrame> frame,
//                            const CefString& request,
//                            bool persistent,
//                            CefRefPtr<Callback> callback) {
//      if (request == "my_request") {
//        callback->Continue("my_response");
//        return true;
//      }
//      return false;  // Not handled.
//    }
//
// 9. Notice that the onSuccess callback is executed in JavaScript.
