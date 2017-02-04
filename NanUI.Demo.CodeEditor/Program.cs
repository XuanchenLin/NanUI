using System;
using System.Windows.Forms;

namespace NanUI.Demo.CodeEditor
{
	using NetDimension.NanUI;

	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (HtmlUILauncher.InitializeChromium())
			{
				//初始化成功，加载程序集内嵌的资源到运行时中
				HtmlUILauncher.RegisterEmbeddedScheme(Resources.SchemeHelper.GetSchemeAssembley(), "http", "www");

				//启动主窗体
				Application.Run(new EditorForm());
			}

			
		}
	}
}
