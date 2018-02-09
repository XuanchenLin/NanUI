var NanUI = NanUI || {};

(function (nui) {
	nui.__defineGetter__("version", function () {
		native function GetVersion();
		return GetVersion();
	});

})(NanUI);