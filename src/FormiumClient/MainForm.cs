using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.JavaScript;
using Xilium.CefGlue;

namespace FormiumClient
{
    public class MainForm : Formium
    {
        // You must indicate a style of HostWindow.
        public override HostWindowType WindowType { get; } = HostWindowType.Borderless;


        // You must specify the startup url here.

        
        public override string StartUrl { get; } = "http://main.app.local/";
        //public override string StartUrl { get; } = "http://localhost:3000"; // For development purpose

        private KisokModeForm kisokModeForm;
        private AcrylicStyleForm acrylicStyleForm;
        private NativeStyleForm nativeStyleForm;
        public MainForm()
        {

            // Set form settings here.

            MinimumSize = new Size(720, 480);
            Size = new Size(1152, 768);
            Icon = Properties.Resources.DefaultIcon;

            Title = "NanUI Example";
            Subtitle = "The WinFormium";

            StartPosition = FormStartPosition.CenterScreen;

            // Set up settings for BorderlessWindow style.

            BorderlessWindowProperties.BorderEffect = BorderEffect.RoundCorner;
            BorderlessWindowProperties.ShadowEffect = ShadowEffect.DropShadow;
            BorderlessWindowProperties.ShadowColor = Color.DimGray;

            // Customize the Splash with Mask property.

            CustomizeMaskPanel();

            // If you don't want show the splash on starup, set AutoShowMask to false.
            //AutoShowMask = false;

        }


        // Create the splash panel
        private void CustomizeMaskPanel()
        {
            var label = new Label
            {
                Text = "WinFormium\nExample Application\nPowered by NanUI",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Light", 24.0f, GraphicsUnit.Point)
            };

            label.Width = Width;
            label.Height = Height / 2;
            label.Location = new Point(0, (Height - label.Height) / 2);

            var loaderGif = new PictureBox
            {
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Size = new Size(40, 40),
                Image = Properties.Resources.Indicator,
                SizeMode = PictureBoxSizeMode.CenterImage
            };

            loaderGif.Location = new Point(Width - (int)(loaderGif.Width * 2.0f), Height - (int)(loaderGif.Height * 1.5f));

            // Add a label

            Mask.Content.Add(label);

            // Add a picture box

            Mask.Content.Add(loaderGif);

            Mask.Image = null;
        }


        // Raise if browser is ready.
        protected override void OnReady()
        {
            // Set browser settings here.

            MapClrObjectToJavaScript();

            RegisterDemoWindowlObject();

            RegisterWindowStyleExampleObject();

            RegisterJavaScriptExampleObject();

            BeforePopup += MainWindow_BeforePopup;

            BeforeClose += MainForm_BeforeClose;

            RenderProcessTerminated += MainForm_RenderProcessTerminated;
        }

        // Raises if the render process is terminated. You can restart it or handle it by yourself. 
        private void MainForm_RenderProcessTerminated(object sender, NetDimension.NanUI.Browser.RenderProcessTerminatedEventArgs e)
        {
            // Set this property to true to restart renderer process automaticlly.
            e.ShouldTryResetProcess = true;
        }

        // Handle BeforeClose event. If you want to do something before user closing this window, you can handle this event.
        private void MainForm_BeforeClose(object sender, NetDimension.NanUI.Browser.FormiumCloseEventArgs e)
        {
            if(MessageBox.Show(this.HostWindow, "Are your sure to quit?", "Quit this App", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Canceled = true;
            }
        }


        // Handle Before Popup event. If links have a target property that value equals "_blank", open the link in default browser of current system.
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


        // Example: Map the CLR objects to NanUI's JavaScript context.
        private void MapClrObjectToJavaScript()
        {
            var obj = JavaScriptValue.CreateObject();

            // Readonly property
            obj.SetValue("now", JavaScriptValue.CreateProperty(() =>
            {
                return JavaScriptValue.CreateDateTime(DateTime.Now);
            }));

            // Value
            obj.SetValue("version", JavaScriptValue.CreateString(Assembly.GetExecutingAssembly().GetName().Version?.ToString()));

            // Readable and writable property
            obj.SetValue("subtitle", JavaScriptValue.CreateProperty(() => JavaScriptValue.CreateString(Subtitle), title => Subtitle = title.GetString()));

            // Sync method
            obj.SetValue("messagebox", JavaScriptValue.CreateFunction(args =>
            {
                var msg = args.FirstOrDefault(x => x.IsString);

                var text = msg?.GetString();

                InvokeIfRequired(() =>
                {
                    MessageBox.Show(HostWindow, text, "Message from JS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });

                return JavaScriptValue.CreateString(text);
            }));

            // Async method
            obj.SetValue("asyncmethod", JavaScriptValue.CreateFunction((args, callback) =>
            {

                Task.Run(async () =>
                {

                    var rnd = new Random(DateTime.Now.Millisecond);

                    var rndValue = rnd.Next(3000, 6000);

                    await Task.Delay(rndValue);
                    callback.Success(JavaScriptValue.CreateString($"Delayed {rndValue} milliseconds"));

                });
            }));

            RegisterExternalObjectValue("tester", obj);
        }

        // Example: Register JavaScript object in current frame.
        private void RegisterJavaScriptExampleObject()
        {
            var jsDemo = JavaScriptValue.CreateObject();

            jsDemo.SetValue("executeJavaScriptWithoutRetval", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(() =>
                {
                    ExecuteJavaScript("alert(1+1)");
                });
                return null;
            }));

            jsDemo.SetValue("executeJavaScriptWithRetval", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(async () =>
                {
                    var result = await EvaluateJavaScriptAsync("(function(){ return {a:1,b:'hello',c:(s)=>alert(s)}; })()");
                    if (result.Success)
                    {
                        var retval = result.ResultValue;
                        MessageBox.Show($"a={retval.GetInt("a")} b={retval.GetString("b")}", "Value from JS");
                        await retval.GetValue("c").ExecuteFunctionAsync(GetMainFrame(), new JavaScriptValue[] { JavaScriptValue.CreateString("Hello from C#") });
                    }
                });
                return null;
            }));

            RegisterExternalObjectValue("jsExamples", jsDemo);

        }

        // Add methods for windowExamples object in Formium.external object in JavaScript context.
        private void RegisterWindowStyleExampleObject()
        {
            var windowStyleDemo = JavaScriptValue.CreateObject();

            windowStyleDemo.SetValue("openNativeStyleForm", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(() =>
                {
                    if (nativeStyleForm == null || nativeStyleForm.IsDisposed)
                    {
                        nativeStyleForm = new NativeStyleForm();
                        nativeStyleForm.Show();

                    }
                    else
                    {
                        if (!nativeStyleForm.Visible)
                        {
                            nativeStyleForm.Show();
                        }
                        nativeStyleForm.Active();
                    }

                });
                return null;
            }));

            windowStyleDemo.SetValue("openKisokModeForm", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(() =>
                {
                    if (kisokModeForm == null || kisokModeForm.IsDisposed)
                    {
                        kisokModeForm = new KisokModeForm();
                        kisokModeForm.Show();
                    }
                    else
                    {
                        kisokModeForm.Close();
                    }

                });
                return null;
            }));

            windowStyleDemo.SetValue("openAcrylicStyleForm", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(() =>
                {
                    if (acrylicStyleForm == null || acrylicStyleForm.IsDisposed)
                    {
                        acrylicStyleForm = new AcrylicStyleForm();
                        acrylicStyleForm.Show(HostWindow);
                    }
                    else
                    {
                        if (!acrylicStyleForm.Visible)
                        {
                            acrylicStyleForm.Show();
                        }
                        acrylicStyleForm.Active();
                    }
                });
                return null;
            }));

            windowStyleDemo.SetValue("openLayeredStyleForm", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(() =>
                {
                    var layeredStyleForm = new LayeredStyleForm();

                    layeredStyleForm.Show(HostWindow);
                });
                return null;
            }));

            

            RegisterExternalObjectValue("windowExamples", windowStyleDemo);

        }

        // Add methods for demo object in Formium.external object in JavaScript context.
        private void RegisterDemoWindowlObject()
        {
            var demoWindow = JavaScriptValue.CreateObject();

            const string GITHUB_URL = "https://github.com/NetDimension/NanUI";

            demoWindow.SetValue("openLicenseWindow", JavaScriptValue.CreateFunction(args =>
            {

                InvokeIfRequired(() =>
                {
                    ShowAboutDialog();
                });

                return null;
            }));

            demoWindow.SetValue("navigateToGitHub", JavaScriptValue.CreateFunction(args =>
            {

                InvokeIfRequired(() =>
                {
                    OpenExternalUrl(GITHUB_URL);
                });

                return null;
            }));

            demoWindow.SetValue("openDevTools", JavaScriptValue.CreateFunction(args =>
            {
                InvokeIfRequired(() =>
                {
                    ShowDevTools();
                });

                return null;
            }));

            demoWindow.SetValue("openLocalFileResourceFolder", JavaScriptValue.CreateFunction(args =>
            {

                InvokeIfRequired(() =>
                {
                    OpenExternalUrl(System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));
                });

                return null;
            }));

            RegisterExternalObjectValue("demo", demoWindow);
        }

    }
}
