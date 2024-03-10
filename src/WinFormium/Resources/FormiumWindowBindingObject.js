var formium;

(function ($window) {

    const CMD_ATTR_PREFIX = "formium-command";

    let isDocumentReady = false;
    let isContextReady = false;

    const readyCallbacks = [];
    const contextReadyCallbacks = [];

    const messageHandlers = {};


    let lastWindowState = null;

    let globalMouseEventHandlerRegistered = false;

    const raiseHostWindowEvent = (eventName, eventArgs) => {

        if (!isContextReady) return;

        window.dispatchEvent(new CustomEvent(
            eventName,
            {
                detail: eventArgs,
                bubbles: true
            })
        );
    };



    class InternalMethods {

        constructor(host) {
            this.hostWindow = host;
        }

        dispatchMessage(message, args) {
            const messageName = message.toLowerCase();

            if (messageHandlers.hasOwnProperty(messageName)) {
                messageHandlers[messageName].apply(this.hostWindow, [args]);
            };
        };

        setContextReadyState() {

            if (isContextReady) return;

            while (contextReadyCallbacks.length > 0) {
                contextReadyCallbacks.pop().apply();
            }

            isContextReady = true;

        };

        setDocumentReadyState() {

             if (isDocumentReady) return;

             const $this = this;

             if (globalMouseEventHandlerRegistered == false) {

                 window.addEventListener("click", (e) => {

                     if (e.button === 0) {

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
                                 fullscreen: "fullScreen"
                             };

                             if (commandMaps.hasOwnProperty(commandString)) {

                                 const command = commandMaps[commandString];

                                 if (command && $this.hostWindow && $this.hostWindow[command]) {

                                     setTimeout(() => {
                                         $this.hostWindow[command].apply($this.hostWindow);
                                     }, 100);

                                     e.stopPropagation();
                                     e.preventDefault();
                                 }
                             }
                         }
                     }
                 });

                 globalMouseEventHandlerRegistered = true;
             }

             while (readyCallbacks.length > 0) {
                 readyCallbacks.pop().apply(this);
             }

             isDocumentReady = true;
         };

        // EVENT : hostwindowstatechanged
        onWindowStateChanged(state) {

            if (lastWindowState == state) return;

            lastWindowState = state;

            const htmlEl = document.querySelector("html");
            htmlEl?.classList.remove("formium--maximized", "formium--fullscreen", "formium--minimized");
            const windowState = state.toLowerCase();

            if (windowState != "normal") {
                htmlEl?.classList.add(`formium--${windowState}`);
            }

            raiseHostWindowEvent("hostwindowstatechanged", { state: windowState });
        };

        // EVENT : hostresized
        onWindowResized(x, y, width, height) {
            raiseHostWindowEvent("hostresized", {
                x,
                y,
                width,
                height,
                rectangle: { left: x, top: y, right: x + width, bottom: y + height, width, height }
            });
        };

        // EVENT : hostmoved
        onWindowMoved(x, y) {
            raiseHostWindowEvent("hostmoved", { x, y });
        };

        // EVENT : hostcolorschemechanged
        onColorSchemeChanged(mode) {

            const htmlEl = document.querySelector("html");

            const modeStr = mode.toLowerCase();

            htmlEl?.classList.remove("formium-color-scheme--dark", "formium-color-scheme--light");
            htmlEl?.classList.add(`formium-color-scheme--${modeStr}`);

            raiseHostWindowEvent("hostcolorschemechanged", { scheme: modeStr });
        }

        // EVENT : hostactivatedstatechanged / hostactivated
        onWindowActivated() {
            const htmlEl = document.querySelector("html");
            htmlEl?.classList.remove("formium--deactivate");
            htmlEl?.classList.add("formium--activated");

            raiseHostWindowEvent("hostactivated", {});
            raiseHostWindowEvent("hostactivatedstatechanged", { activated: true });
        };

        // EVENT : hostactivatedstatechanged / hostactivated
        onWindowDeactivate() {
            const htmlEl = document.querySelector("html");
            htmlEl?.classList.remove("formium--activated");
            htmlEl?.classList.add("formium--deactivate");

            raiseHostWindowEvent("hostdeactivate", {});
            raiseHostWindowEvent("hostactivatedstatechanged", { activated: false });
        };



    }

    class HostWindow {
        internal = new InternalMethods(this);

        get #isEmbeddedInControl() {
            native function IsEmbeddedInControl();
            return IsEmbeddedInControl();
        }

        get isFramelessWindow() {
            native function IsFramelessWindow();
            return IsFramelessWindow();
        }

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

        get bounds() {
            native function GetWindowRectangle();
            return GetWindowRectangle();
        }

        minimize() {
            if (this.#isEmbeddedInControl) return;
            native function Minimize();
            return Minimize();
        };

        maximize() {
            if (this.#isEmbeddedInControl) return;
            native function Maximize();
            return Maximize();
        };

        close() {
            if (this.#isEmbeddedInControl) return;
            native function Close();
            return Close();
        };

        restore() {
            if (this.#isEmbeddedInControl) return;
            native function Restore();
            return Restore();
        };

        fullScreen() {
            if (this.#isEmbeddedInControl) return;
            native function FullScreen();
            return FullScreen();
        };

        moveTo(x, y) {
            if (this.#isEmbeddedInControl) return;
            native function MoveTo();
            return MoveTo(x, y);
        };

        moveBy(deltaX, deltaY) {
            if (this.#isEmbeddedInControl) return;
            native function MoveBy();
            return MoveBy(deltaX, deltaY);
        };

        sizeTo(width, height) {
            if (this.#isEmbeddedInControl) return;
            native function SizeTo();
            return SizeTo(width, height);
        };

        sizeBy(deltaX, deltaY) {
            if (this.#isEmbeddedInControl) return;
            native function SizeBy();
            return SizeBy(deltaX, deltaY);
        };

        active() {
            if (this.#isEmbeddedInControl) return;
            native function Active();
            return Active();
        };

        center() {
            if (this.#isEmbeddedInControl) return;
            native function Center();
            return Center();
        };

        minimize() {
            if (this.#isEmbeddedInControl) return;
            native function Minimize();
            return Minimize();
        };

        maximize() {
            if (this.#isEmbeddedInControl) return;
            native function Maximize();
            return Maximize();
        };

        close() {
            if (this.#isEmbeddedInControl) return;
            native function Close();
            return Close();
        };
    }


    class Formium {
        get culture() {
            native function GetCurrentCulture();
            return GetCurrentCulture();
        };

        hostWindow = new HostWindow();

        version = {
            get WinFormium() {
                native function GetWinFormiumVersion();
                return GetWinFormiumVersion();
            },
            get Chromium() {
                native function GetChromiumVersion();
                return GetChromiumVersion();
            },
            get Application() {
                native function GetApplicationVersion();
                return GetApplicationVersion();
            },
        };


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

        postMessage(message, args) {
            native function PostHostWindowMessage();
            return PostHostWindowMessage(message, args);
        };

        onMessage(message, callback) {
            if (message === null || message === "" || typeof (message) !== 'string') throw "message is null or empty";

            const messageName = message.toLowerCase();

            messageHandlers[messageName] = callback;
        }

        addMessageHandler(message, callback) {

            if (message === null || message === "" || typeof (message) !== 'string') throw "message is null or empty";

            const messageName = message.toLowerCase();

            messageHandlers[messageName] = callback;
        };

        removeMessageHandler(message) {
            if (message === null || message === "" || typeof (message) !== 'string') throw "message is null or empty";

            const messageName = message.toLowerCase();

            if (messageHandlers.hasOwnProperty(messageName)) {
                delete messageHandlers[messageName];
            };
        };

        sendRequest(message, args) {
            native function SendHostWindowMessageRequest();
            return SendHostWindowMessageRequest(message, args);
        };

        sendRequestAsync(message, args) {
            native function SendHostWindowMessageRequestAsync();
            return SendHostWindowMessageRequestAsync(message, args);
        }
    }

    $window.formium = new Formium();
})(this);
