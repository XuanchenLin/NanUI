using System.Diagnostics;
using System.Reflection;

using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.JavaScript;

namespace FormiumClient;

class MainWindow : Formium
{
    public override string StartUrl { get; } = "http://resources.app.local/client-ui/";
    public override HostWindowType WindowType { get; } = HostWindowType.Borderless;

    protected override bool DisableAboutMenu => true;

    public MainWindow()
    {
        // Set Form settings here.
        // 在此处设置窗体的各种属性

        MinimumSize = new Size(720, 480);
        Size = new Size(1280, 800);

        StartPosition = FormStartPosition.CenterScreen;

        // Set up settings for BorderlessWindow style.
        // 设置 Borderless 样式窗体的各项扩展属性，需要注意泛型T需要对应正确的WindowType
        var style = UseExtendedStyles<BorderlessWindowStyle>();
        //style.ShadowColor = ColorTranslator.FromHtml("#8B6A91");
        //style.InactiveShadowColor = ColorTranslator.FromHtml("#EE3a3a3a");
        style.ShadowColor = ColorTranslator.FromHtml("#EE3a3a3a");
        style.ShadowEffect = ShadowEffect.Huge;
        style.CornerStyle = CornerStyle.Small;

        // Set up Splash styles
        // 设置启动画面的各种参数
        SplashScreen.AutoHide = false;

        CustomizeSplashScreen();
    }

    private void CustomizeSplashScreen()
    {
        SplashScreen.BackColor = ColorTranslator.FromHtml("#8368A6");

        // Add a label
        // 添加一个Label组件

        //var label = new Label
        //{
        //    Text = "Welcome to\nNanUI Example Application",
        //    AutoSize = false,
        //    TextAlign = ContentAlignment.MiddleCenter,
        //    Anchor = AnchorStyles.None,
        //    BackColor = Color.Transparent,
        //    Font = new Font("Segoe UI Light", 24.0f, GraphicsUnit.Point)
        //};

        //label.Width = Width / 2;
        //label.Height = Height / 3;
        //label.Location = new Point((Width - label.Width) / 2, (Height - label.Height));

        //SplashScreen.Content.Add(label);

        // Add a picture box
        // 添加一个PictureBox组件放置加载动画

        var loaderGif = new PictureBox
        {
            Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            Size = new Size(50, 50),
            Image = Properties.Resources.Indicator,
            SizeMode = PictureBoxSizeMode.CenterImage,
            BorderStyle = BorderStyle.None,
            BackColor = Color.Transparent,

        };

        loaderGif.Location = new Point(Width - (int)(loaderGif.Width) - 20, Height - (int)(loaderGif.Height) - 20);

        SplashScreen.Content.Add(loaderGif);



        // 特别提示：如果使用SystemBorderless样式，请勿将此属性设置为null。
        // 因为DWM渲染机制，如果图片为空那么整个Panel都将停止渲染，所以这里使用一张透明的png图片来骗过DWM。

        //SplashScreen.Image = Properties.Resources.TransparentBG;
    }

    protected override void OnReady()
    {

        // Example of registering JavaScript objects
        // 测试JavaScript对象注册
        TestRegisterJavaScriptObject();

        // Register JavaScript object and methods for this window.
        RegisterDemoWindowObject();

        // Register the JavaScript object and methods for JavaScript example page.
        RegisterJavaScriptExampleObject();

        // Register the JavaScript object and methods of the Window Types example page
        RegisterWindowStyleExampleObject();

        // Register event handler before a popup window will be shown.
        // 注册弹出窗口弹出前事件
        BeforePopup += MainWindow_BeforePopup;

        // Register event handler before the window will be closed.
        // 注册窗口关闭前事件
        BeforeClose += MainWindow_BeforeClose;

        // Register event handler when page is loaded
        // 注册页面加载完成事件
        LoadEnd += BrowserLoadEnd;

        // Register event handler when keyboard is pressed
        // 注册按键事件
        KeyEvent += MainWindow_KeyEvent;

    }



    #region Events
    private void MainWindow_BeforePopup(object sender, NetDimension.NanUI.Browser.BeforePopupEventArgs e)
    {
        e.Handled = true;

        InvokeIfRequired(() =>
        {
            OpenExternalUrl(e.TargetUrl);
        });
    }

    private void OpenExternalUrl(string url)
    {
        var ps = new System.Diagnostics.ProcessStartInfo(url)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        System.Diagnostics.Process.Start(ps);
    }

    private void BrowserLoadEnd(object sender, NetDimension.NanUI.Browser.LoadEndEventArgs e)
    {
        if (e.Frame.IsMain && e.HttpStatusCode == 200)
        {
            SendDataMessage("test", new { a = 1, b = 2, c = "hello world" });
        }
    }


    private void MainWindow_BeforeClose(object sender, NetDimension.NanUI.Browser.FormiumCloseEventArgs e)
    {
        if (MessageBox.Show(WindowHandle, "确定关闭？", "关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        {
            e.Canceled = true;
        }
    }

    private void MainWindow_KeyEvent(object sender, NetDimension.NanUI.Browser.KeyEventArgs e)
    {
        //Force reload the page when F5 is pressed
        //注册F5键按下时强制刷新页面
        if (e.KeyEvent.EventType == Xilium.CefGlue.CefKeyEventType.KeyUp && e.KeyEvent.WindowsKeyCode == (int)Keys.F5)
        {
            Reload(true);
        }

        // Show DevTools when F12 is pressed
        // 注册F12键按下时打开开发者工具
        if (e.KeyEvent.EventType == Xilium.CefGlue.CefKeyEventType.KeyUp && e.KeyEvent.WindowsKeyCode == (int)Keys.F12)
        {
            ShowDevTools();
        }
    }
    #endregion

    #region JavaScript Examples
    private async void TestEvaluateJavaScriptAsync()
    {
        // Create a JavaScript Object
        // 创建 JS 对象
        var fobj = new JavaScriptObject();

        // Define a property to JavaScript Object
        // 在 JS 对象上定义一个属性
        fobj.DefineProperty("test",
            () => new JavaScriptValue(Title),
            (v) =>
            {
                InvokeIfRequired(() => MessageBox.Show(WindowHandle, $"JavaScript Result: {v.GetString()}", "JavaScript"));
            }
        );

        // Execute JavaScript with return code
        // 执行带有返回结果的 JS 代码
        var retval = await EvaluateJavaScriptAsync(@"
(function() { 
return { 
    a:1,
    b:'Hello NanUI',
    c:(text)=>console.log(text||'hello with empty text'),
    d:(callback)=> {
        callback(111)
            .then(x=>console.log(`success:${x}`))
            .catch(m=>console.log(`error:${m}`));
    },
    e:(s)=> s? `hello ${s}` : `hello from javascript`,
    f:(o)=>{
        console.log(o.test);
        setTimeout(()=>o.test=new Date(),2000);
    }
}; 
})()");

        // The return value of JavaScript above
        // 上面 JS 代码的返回值
        var obj = retval.Value.ToObject();

        var valueA = obj["a"].GetInt();

        var valueB = obj["b"].GetString();

        InvokeIfRequired(() =>
        {
            MessageBox.Show(WindowHandle, $"a={valueA} b={valueB}", "Value from JavaScript", MessageBoxButtons.OK, MessageBoxIcon.Information);
        });

        await obj["c"].ExecuteAsync(new JavaScriptValue("Hello World!"));

        await obj["c"].ExecuteAsync(new JavaScriptValue("Goodbye World!"));

        // Execute async function in the returned JavaScript object.
        // 执行异步方法
        var d1 = await obj["d"].ExecuteAsync(new JavaScriptAsyncFunction(async (args, promise) =>
        {
            await Task.Delay(5000);
            promise.Resovle(new JavaScriptValue("delayed message: hello!"));
        }));


        var d2 = await obj["d"].ExecuteAsync(new JavaScriptAsyncFunction((args, promise) =>
        {
            promise.Reject("Oops! This will be caught by catch method in a promise.");
        }));

        var e1 = await obj["e"].ExecuteAsync();
        var e2 = await obj["e"].ExecuteAsync(new JavaScriptValue("Xuanchen Lin"));

        var f = await obj["f"].ExecuteAsync(fobj);
    }


    private void TestRegisterJavaScriptObject()
    {
        // Create a JavaScript Object
        // 创建 JS 对象
        var pObj = new JavaScriptObject();

        pObj.DefineProperty("title", () => new JavaScriptValue(Title), (v) =>
        {
            InvokeIfRequired(() => Title = v);
        });

        pObj.Add("version", $"{Assembly.GetExecutingAssembly().GetName().Version}");

        pObj.Add("syncfunc", (args) =>
        {
            InvokeIfRequired(() =>
            {
                var x = args.Count > 0 ? args[0] : "no content";
                MessageBox.Show(WindowHandle, $"JavaScript Result: {x}", "Test");
            });

            return null;
        }
        );

        var childObj = new JavaScriptObject();

        childObj.DefineProperty("now", () => new JavaScriptValue(DateTime.Now));

        childObj.Add("msgbox", (args) =>
        {
            var msg = args.FirstOrDefault(x => x.IsString)?.GetString() ?? "Nothing";

            InvokeIfRequired(() =>
            {
                MessageBox.Show(WindowHandle, $"JavaScript said: {msg}", "Message from JavaScript");
            });

            return null;
        });

        childObj.Add("NullTest", new JavaScriptValue());

        pObj.Add("innerObject", childObj);

        pObj.Add("jsonObject", new JavaScriptJsonValue(new { a = 1, b = 2, c = "test" }));

        pObj.Add("asyncfunc", async (args, promise) =>
        {
            var delayedExpire = new Random().Next(3000);

            await Task.Delay(delayedExpire);

            var rnd = new Random().Next(20);

            if (rnd <= 5)
            {
                // 模拟Reject情况，让这个异步方法有几率触发reject
                promise.Reject($"[REJECTED]: Delayed for {delayedExpire} ms");
            }
            else
            {
                promise.Resovle(new JavaScriptValue($"[RESOVLED]: Delayed for {delayedExpire} ms"));
            }
        });


        // Register object in to JavaScript
        // 把对象注册到 JS 环境
        RegisterJavaScriptObject("tester", pObj);
    }
    #endregion

    #region Register Example Objects
    private void RegisterDemoWindowObject()
    {
        var demoWindow = new JavaScriptObject();


        demoWindow.Add("openLicenseWindow", (args =>
        {

            ShowAboutDialog();

            return null;
        }));


        demoWindow.Add("openDevTools", (args =>
        {
            InvokeIfRequired(() =>
            {
                ShowDevTools();
            });

            return null;
        }));

        demoWindow.Add("openLocalFileResourceFolder", (args =>
        {

            InvokeIfRequired(() =>
            {
                OpenExternalUrl(System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));
            });

            return null;
        }));

        RegisterJavaScriptObject("demo", demoWindow);
    }

    private void RegisterJavaScriptExampleObject()
    {
        var jsDemo = new JavaScriptObject();

        jsDemo.Add("executeJavaScriptWithoutRetval", (args =>
        {
            InvokeIfRequired(() =>
            {
                ExecuteJavaScript("alert(1+1)");
            });
            return null;
        }));

        jsDemo.Add("executeJavaScriptWithRetval", (args =>
        {
            InvokeIfRequired(() =>
            {
                TestEvaluateJavaScriptAsync();

            });
            return null;
        }));

        RegisterJavaScriptObject("jsExamples", jsDemo);

    }



    SystemWindowDemo sysemStyleWindow;
    BorderlessWindowDemo borderlessStyleWindow;
    SystemBorderlessDemo systemBorderlessStyleWindow;
    LayeredWindowDemo layeredStyleWindow;
    KioskWindowDemo kioskStyleWindow;

    // Add methods for windowExamples object in Formium.external object in JavaScript context.
    private void RegisterWindowStyleExampleObject()
    {
        var windowStyleDemo = new JavaScriptObject();

        windowStyleDemo.Add("openSystemWindowDemo", (args =>
        {
            InvokeIfRequired(() =>
            {
                if (sysemStyleWindow == null || sysemStyleWindow.IsDisposed)
                {
                    sysemStyleWindow = new SystemWindowDemo();
                    sysemStyleWindow.Show(this);

                }
                else
                {
                    if (!sysemStyleWindow.Visible)
                    {
                        sysemStyleWindow.Show(this);
                    }
                    sysemStyleWindow.Active();
                }

            });
            return null;
        }));

        windowStyleDemo.Add("openBorderlessWindowDemo", (args =>
        {
            InvokeIfRequired(() =>
            {
                if (borderlessStyleWindow == null || borderlessStyleWindow.IsDisposed)
                {
                    borderlessStyleWindow = new BorderlessWindowDemo();
                    borderlessStyleWindow.Show(this);

                }
                else
                {
                    if (!borderlessStyleWindow.Visible)
                    {
                        borderlessStyleWindow.Show(this);
                    }
                    borderlessStyleWindow.Active();
                }

            });
            return null;
        }));


        windowStyleDemo.Add("openSystemBorderlessWindowDemo", (args =>
        {
            InvokeIfRequired(() =>
            {
                if (systemBorderlessStyleWindow == null || systemBorderlessStyleWindow.IsDisposed)
                {
                    systemBorderlessStyleWindow = new SystemBorderlessDemo();
                    systemBorderlessStyleWindow.Show(this);

                }
                else
                {
                    if (!systemBorderlessStyleWindow.Visible)
                    {
                        systemBorderlessStyleWindow.Show(this);
                    }
                    systemBorderlessStyleWindow.Active();
                }

            });
            return null;
        }));

        windowStyleDemo.Add("openLayeredWindowDemo", (args =>
        {
            InvokeIfRequired(() =>
            {

                if (layeredStyleWindow == null || layeredStyleWindow.IsDisposed)
                {
                    layeredStyleWindow = new LayeredWindowDemo();
                    layeredStyleWindow.Show(this);

                }
                else
                {
                    if (!layeredStyleWindow.Visible)
                    {
                        layeredStyleWindow.Show(this);
                    }
                    layeredStyleWindow.Active();
                }
            });
            return null;
        }));

        windowStyleDemo.Add("openKioskWindowDemo", (args =>
        {
            InvokeIfRequired(() =>
            {

                if (kioskStyleWindow == null || kioskStyleWindow.IsDisposed)
                {
                    kioskStyleWindow = new KioskWindowDemo();
                    kioskStyleWindow.Show(this);

                }
                else
                {
                    if (!kioskStyleWindow.Visible)
                    {
                        kioskStyleWindow.Show();
                    }
                    kioskStyleWindow.Active();
                }
            });
            return null;
        }));


        RegisterJavaScriptObject("windowExamples", windowStyleDemo);

    }
    #endregion

    #region JavaScript Window Binding

    #endregion
}

