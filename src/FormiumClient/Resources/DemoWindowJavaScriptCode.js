var DemoWindow = DemoWindow || {};


(($this) => {

    $this.test = (msg1, msg2) => {
        native function Test();
        return Test(msg1, msg2);
    };

    $this.add = (a, b) => {
        native function Add();
        return Add(a, b);
    };

    $this.delay = (time, message) => {
        native function Delay();
        return Delay(time, message);
    };



    $this.hello = (message) => {
        native function Hello();
        return Hello(message);
    };

    $this.helloAsync = (time, message) => {
        native function HelloAsync();
        return HelloAsync(time, message);
    };

    $this.__defineGetter__("title", () => {
        native function GetTitle();
        return GetTitle();
    });

    $this.__defineSetter__("title", (title) => {
        native function SetTitle();
        return SetTitle(title);
    });

})(DemoWindow);