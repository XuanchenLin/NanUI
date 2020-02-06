var NanUI = NanUI || {};

(function (target) {

  target.__defineGetter__("version", function () {
    native function Version();
    return Version();
  });
  
})(NanUI);