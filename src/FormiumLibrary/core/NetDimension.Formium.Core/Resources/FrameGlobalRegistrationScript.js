var NanUI = NanUI || {};

(function(target) {
  const CMD_ATTR_PREFIX = "nanui-command";

  const RAISE_FUNC_NAME = "__nanui_raiseHostWindowEvent";

  const GLOBAL_CLICK_HANDLER_REGISTERED =
    "__nanui_global_click_handler_registered";

  if (!window.hasOwnProperty(RAISE_FUNC_NAME)) {
    window[RAISE_FUNC_NAME] = function(eventName, data) {
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
        const command = srcElement.getAttribute(CMD_ATTR_PREFIX);
        if (
          command &&
          target &&
          target.hostWindow &&
          target.hostWindow[command]
        ) {
          target.hostWindow[command].apply(target);
        }
      }
    });

    window[GLOBAL_CLICK_HANDLER_REGISTERED] = true;
  }
})(NanUI);
