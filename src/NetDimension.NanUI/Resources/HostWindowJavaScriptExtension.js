var Formium = Formium || {};

(function ($this) {

    const CMD_ATTR_PREFIX = "formium-command";

    const RAISE_FUNC_NAME = "__formium_raiseHostWindowEvent";

    const GLOBAL_CLICK_HANDLER_REGISTERED =
        "__formium_global_click_handler_registered";


    let isV8Ready = false;

    let isDomReady = false;

    const readyFunctions = [];

    const contextReadyFunctions = [];

    $this._setContextReady =  () => {

        isV8Ready = true;

        if (!window.hasOwnProperty(RAISE_FUNC_NAME)) {
            window[RAISE_FUNC_NAME] = function (eventName, data) {
                window.dispatchEvent(new CustomEvent(eventName, { detail: data }));
            };
        }

        if (!(GLOBAL_CLICK_HANDLER_REGISTERED in window)) {

            window.addEventListener("click", e => {


                let srcElement = e.srcElement;


                while (srcElement && !srcElement.hasAttribute(CMD_ATTR_PREFIX)) {
                    srcElement = srcElement.parentElement;
                }

                if (srcElement) {
                    const command = srcElement.getAttribute(CMD_ATTR_PREFIX).toLowerCase();
                    
                    if (command && $this.hostWindow && $this.hostWindow[command]) {
                        e.stopPropagation();
                        e.preventDefault();
                        $this.hostWindow[command].apply($this);
                    }

                }
            });

            window[GLOBAL_CLICK_HANDLER_REGISTERED] = true;
        }

        while (contextReadyFunctions.length > 0) {
            const fn = contextReadyFunctions.pop();
            fn.apply($this);
        }


    };

    $this._setDomReady = () => {
        isDomReady = true;

        while (readyFunctions.length > 0) {
            const fn = readyFunctions.pop();
            fn.apply($this);

            //console.log("run delayed");
        }
        
    };

    $this.__defineGetter__("culture", () => {
        native function GetCultureInfo();
        return GetCultureInfo();
    });

    $this.onReady = (fn) => {

        if (typeof (fn) === "function") {
            if (isDomReady) {
                fn.apply($this);
            }
            else {
                readyFunctions.push(fn);
            }
        }
    }

    $this.onContextReady = (fn) => {
        if (typeof (fn) === "function") {
            if (isV8Ready) {
                fn.apply($this);
            }
            else {
                contextReadyFunctions.push(fn);
            }
        }
    }

    // host window
    const hostWindow = {
        minimize() {
            native function Minimize();
            return Minimize();
        },
        maximize() {
            native function Maximize();
            return Maximize();
        },
        close() {
            native function Close();
            return Close();
        },
        restore() {
            native function Restore();
            return Restore();
        },
        fullScreen() {
            native function FullScreen();
            return FullScreen();
        },
        moveTo(x, y) {
            native function MoveTo();
            return MoveTo(x, y);
        },
        sizeTo(width, height) {
            native function SizeTo();
            return SizeTo(width, height);
        },
        getWindowState() {
            native function GetWindowState();
            return GetWindowState();
        },
        getWindowRectangle() {
            native function GetWindowRectangle();
            return GetWindowRectangle();
        },
        active() {
            native function Active();
            return Active();
        },
        mask: {
            show() {
                native function ShowMask();
                return ShowMask();
            },
            close() {
                native function HideMask();
                return HideMask();
            }
        }
        
    };

    Object.assign($this, {
        hostWindow
    });

    // network

    const network = {
        isNetworkAvailable() {
            native function IsNetworkAvailable();
            return IsNetworkAvailable();
        }
    };

    Object.assign($this, {
        network
    });


    // version

    const version = {

    };

    version.__defineGetter__("formium", () => {
        native function GetWinFormiumVersion();
        return GetWinFormiumVersion();
    });

    version.__defineGetter__("chromium", () => {
        native function GetChromiumVersion();
        return GetChromiumVersion();
    });



    Object.assign($this, {
        version
    });


})(Formium);


