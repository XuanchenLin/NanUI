using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace UseEmbeddedResourcesDemoApp
{
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
			if (Bootstrap.Load(PlatformArch.Auto, System.IO.Path.Combine(Application.StartupPath, "fx"), System.IO.Path.Combine(Application.StartupPath, "fx\\Resources"), System.IO.Path.Combine(Application.StartupPath, "fx\\Resources\\locales")))
			{
				//Register html/css/javascript/image resources in current executing assembly. 
				//If you want to embed any kind of resource in your app, just add it to your project and set the Build Action to Embedded Resource.
				Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly(), "my.resource.local");

				//Also, you can load embedded resources from other assemblies.
				var anotherAssembly = System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(Application.StartupPath, "EmbeddedResourcesInSplitAssembly.dll"));
				Bootstrap.RegisterAssemblyResources(anotherAssembly, "your.resource.local");

				Application.Run(new Form1());
			}
		}
	}
}
