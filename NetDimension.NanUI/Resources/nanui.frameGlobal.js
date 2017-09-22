(function () {
	window["raiseCustomEvent"] = function (eventName, customDetail) {
		window.dispatchEvent(new CustomEvent(eventName, { detail: customDetail }));
	}
	const ATTR_NAME = "n-ui-command";

	document.addEventListener("DOMContentLoaded", () => {
		document.body.addEventListener("click", (e) => {
			var targetEl = e.srcElement;
						
			while (targetEl && !targetEl.hasAttribute(ATTR_NAME))
			{
				targetEl = targetEl.parentElement;
			}

			if (targetEl) {
				var cmd = targetEl.getAttribute(ATTR_NAME);

				if (cmd && NanUI) {
					NanUI.hostWindow[cmd].apply(NanUI, [e]);
				}
			}
			
		});
	});
})();

