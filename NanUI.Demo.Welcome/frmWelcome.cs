using Chromium;
using NetDimension.NanUI;

namespace NanUI.Demo.Welcome
{
	public partial class frmWelcome : HtmlUIForm    //继承HtmlUIForm
	{
		public frmWelcome()
			: base("http://res.welcome.local/www/index.html") //设定启示页面，scheme是embedded就是我们在Main里注册的当前程序集资源
		{
			InitializeComponent();

			//在js中注册一个方法来打开About窗口
			GlobalObject.AddFunction("showAboutForm").Execute += (sender, args) =>
			{
				ShowAboutNanUI();
				//ShowAboutWindow();
			};

			GlobalObject.AddFunction("showDevTools").Execute += (sender, args) =>
			{
				ShowDevTools();
			};

			LifeSpanHandler.OnBeforePopup += (sender, args) =>
			{

			};

			LifeSpanHandler.OnAfterCreated += (sender, args) =>
			{

			};

			//网页加载完成时触发事件
			LoadHandler.OnLoadEnd += (sender, args) =>
			{
				//判断下触发的事件是不是主框架的
				if (args.Frame.IsMain)
				{

					//ShowDevTools();

					//执行JS，将当前的CEF运行版本等信息通过JS加载到网页上
					var js = $"$client.setRuntimeInfo({{ api: ['{CfxRuntime.ApiHash(0)}', '{CfxRuntime.ApiHash(1)}'], cef:'{CfxRuntime.GetCefVersion()}', chrome:'{CfxRuntime.GetChromeVersion()}',os:'{CfxRuntime.PlatformOS}', arch:'{CfxRuntime.PlatformArch}'}});";
					ExecuteJavascript(js);
				}


			};

		}


	}
}
