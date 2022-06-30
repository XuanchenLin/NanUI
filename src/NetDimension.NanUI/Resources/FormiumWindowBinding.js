var Formium;

(function ($) {
    function WinFormium() {
        const CMD_ATTR_PREFIX = "formium-command";
        const RAISE_FUNC_NAME = "__formium_raiseHostWindowEvent";
        const GLOBAL_CLICK_HANDLER_REGISTERED =
            "__formium_global_click_handler_registered";

        let isDocumentReady = false;
        let isContextReady = false;

        const readyCallbacks = [];
        const contextReadyCallbacks = [];

        const dataMessageHandlers = [];

        class WinFormium {



            __setContextReady__() {

                while (contextReadyCallbacks.length > 0) {
                    contextReadyCallbacks.pop().apply(this);
                }

                isContextReady = true;

                //console.log("NanUI Context is ready!");
            };


            __setDocumentReady__() {

                const $target = this;


                window[RAISE_FUNC_NAME] = (eventName, data) => {
                    window.dispatchEvent(new CustomEvent(
                        eventName,
                        {
                            detail: data,
                            bubbles: true
                        })
                    );
                }

                if (!window.hasOwnProperty(GLOBAL_CLICK_HANDLER_REGISTERED)) {
                    window.addEventListener("click", e => {
                        let srcElement = e.target;

                        while (srcElement && !srcElement.hasAttribute(CMD_ATTR_PREFIX)) {
                            srcElement = srcElement.parentElement;
                        }

                        if (srcElement) {

                            const commandString = srcElement.getAttribute(CMD_ATTR_PREFIX).toLowerCase();

                            const commandMaps = {
                                close: "close",
                                maximize: "maximize",
                                minimize: "minimize",
                                restore: "restore",
                                close: "close",
                                fullscreen: "fullScreen"
                            };

                            if (commandMaps.hasOwnProperty(commandString)) {

                                const { hostWindow } = Formium;
                                const command = commandMaps[commandString];

                                if (command && hostWindow && hostWindow[command]) {

                                    e.stopPropagation();
                                    e.preventDefault();

                                    hostWindow[command].apply($target);
                                }
                            }


                        }
                    });

                    window[GLOBAL_CLICK_HANDLER_REGISTERED] = true;
                }


                while (readyCallbacks.length > 0) {
                    readyCallbacks.pop().apply(this);
                }

                isDocumentReady = true;

                //console.log("NanUI document object is ready!");
            };


            __onDataMessageReceived__(message, base64) {
                if (typeof base64 === "undefined" || base64 == null) {
                    while (dataMessageHandlers.length > 0) {
                        dataMessageHandlers.pop().apply(this, [message]);
                    }
                }
                else {
                    if (dataMessageHandlers.length > 0) {
                        const json = JSON.parse(window.atob(base64));
                        while (dataMessageHandlers.length > 0) {
                            dataMessageHandlers.pop().apply(this, [message, json]);
                        }
                    }
                }
            }


            onDocumentReady(callback) {

                if (isDocumentReady) {
                    callback.apply(this);
                }
                else {
                    readyCallbacks.push(callback);
                }

            };

            onContextReady(callback) {

                if (isContextReady) {
                    callback.apply(this);
                }
                else {
                    contextReadyCallbacks.push(callback);
                }

            };

            onDataMessageReceived(handler) {
                dataMessageHandlers.push(handler);
            }

            sendDataMessage(messageName, data) {
                native function SendDataMessage();
                return SendDataMessage(messageName, JSON.stringify(data));
            }

            hostWindow = new HostWindowInterface();

            version = new Version();

            network = new NetworkInterface();


            get culture() {
                native function GetCurrentCulture();
                return GetCurrentCulture();
            }



        }

        const $this = new WinFormium();

        $this["__createFormiumPromiseFunction__"] = function () {

            const result = {};

            const promise = new Promise(function (resolve, reject) {
                result.resolve = resolve;

                result.reject = reject;
            });

            result.promise = promise;

            return result;
        }

        return $this;
    }

    function HostWindowInterface() {

        class SplashScreen {
            show() {
                native function ShowSplashScreen();
                return ShowSplashScreen();
            }

            hide() {
                native function HideSplashScreen();
                return HideSplashScreen();
            }
        }

        class BorderlessWindowOptions {

            get cornerStyle() {
                native function GetCornerStyle();
                return GetCornerStyle();
            }

            set cornerStyle(config) {
                native function SetCornerStyle();
                return SetCornerStyle(config);
            }

            get shadowEffect() {
                native function GetShadowEffect();
                return GetShadowEffect();
            }
            set shadowEffect(config) {
                native function SetShadowEffect();
                return SetShadowEffect(config);
            }

            get shadowColor() {
                native function GetShadowColor();
                return GetShadowColor();
            }

            set shadowColor(value) {
                native function SetShadowColor();
                return SetShadowColor(value);
            }

            get inactiveShadowColor() {
                native function GetInactiveShadowColor();
                return GetInactiveShadowColor();
            }

            set inactiveShadowColor(value) {
                native function SetInactiveShadowColor();
                return SetInactiveShadowColor(value);
            }
        }

        class HostWindow {
            minimize() {
                native function Minimize();
                return Minimize();
            }

            maximize() {
                native function Maximize();
                return Maximize();
            }

            close() {
                native function Close();
                return Close();
            }

            restore() {
                native function Restore();
                return Restore();
            }

            fullScreen() {
                native function FullScreen();
                return FullScreen();
            }

            moveTo(x, y) {
                native function MoveTo();
                return MoveTo(x, y);
            }

            moveBy(deltaX, deltaY) {
                native function MoveBy();
                return MoveBy(deltaX, deltaY);
            }

            sizeTo(width, height) {
                native function SizeTo();
                return SizeTo(width, height);
            }

            sizeBy(deltaX, deltaY) {
                native function SizeBy();
                return SizeBy(deltaX, deltaY);
            }

            active() {
                native function Active();
                return Active();
            }

            center() {
                native function Center();
                return Center();
            }

            borderlessWindow = new BorderlessWindowOptions();

            splashScreen = new SplashScreen();

            get windowState() {
                native function GetWindowState();
                return GetWindowState();
            }


            get location() {
                native function GetWindowLocation();
                return GetWindowLocation();
            }

            get size() {
                native function GetWindowSize();
                return GetWindowSize();
            }

            get rectangle() {
                native function GetWindowRectangle();
                return GetWindowRectangle();
            }

        }

        return new HostWindow();
    }

    function NetworkInterface() {
        class Network {
            isNetworkAvailable() {
                native function GetNetworkAvailableStatus();
                return GetNetworkAvailableStatus();
            }
        }

        return new Network();
    }

    function Version() {
        class Version {
            get formium() {
                native function GetWinFormiumVersion();
                return GetWinFormiumVersion();
            }

            get chromium() {
                native function GetChromiumVersion();
                return GetChromiumVersion();
            }
        }

        return new Version();
    }




    $.Formium = new WinFormium();



})(this);

