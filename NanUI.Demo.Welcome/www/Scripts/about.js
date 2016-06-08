var win;

(function (win) {

	function disableMenuNSelection() {
		function handler(e) {
			if (e.srcElement.tagName === 'INPUT') {
				var target = e.srcElement;
				var t = target.type;
				if (t != "text" && t != "password" && t != "textarea") {
					return false;
				}
			}
			else {
				return false;
			}
		}
		$(document.body).on("selectstart", function (e) { return handler(event); });
		$(document.body).on("contextmenu", function (e) { return handler(event); });

	}

	jQuery(function () {
		disableMenuNSelection();

		$(window).on('windowstatechanged', function (e) {
			var el = $('.-cef-win-maximize');
			if (e.detail.state == 2) {
				el.text('\u0032');
			}
			else {
				el.text('\u0031');
			}
		});
	});


})(win || (win = {}));
