var NanUI = NanUI || {};

(function (target) {
    var hostWindow = {
        minimize: function () {
            native function Minimize();
            return Minimize();
        },
        maximize: function () {
            native function Maximize();
            return Maximize();
        },
        restore: function () {
            native function Restore();
            return Restore();
        },
        close: function () {
            native function Close();
            return Close();
        },
        sizeTo: function (width, height) {
            native function SizeTo();
            return SizeTo(width, height);
        },
        moveTo: function (x, y) {
            native function MoveTo();
            return MoveTo(x, y);
        }
    };

    hostWindow.__defineGetter__("state", function () {
        native function GetHostWindowState();
        return GetHostWindowState();
    });

    hostWindow.__defineGetter__("width", function () {
        native function GetHostWindowWidth();
        return GetHostWindowWidth();
    });

    hostWindow.__defineGetter__("height", function () {
        native function GetHostWindowHeight();
        return GetHostWindowHeight();
    });

    Object.assign(target, {hostWindow: hostWindow});

    
})(NanUI);