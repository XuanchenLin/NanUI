using Chromium;
using System.Reflection;

namespace NetDimension.NanUI.Resource
{
	internal class EmbeddedSchemeHandlerFactory : CfxSchemeHandlerFactory
	{
		public string SchemeName
		{
			get;
			private set;
		}

		private readonly Assembly resourceAssembly;

		internal EmbeddedSchemeHandlerFactory(string schemeName, Assembly resourceAssembly)
		{



			this.resourceAssembly = resourceAssembly;
			this.SchemeName = schemeName;

			this.Create += EmbeddedSchemeHandlerFactory_Create;
		}

		private void EmbeddedSchemeHandlerFactory_Create(object sender, Chromium.Event.CfxSchemeHandlerFactoryCreateEventArgs e)
		{


			if (e.SchemeName == SchemeName && e.Browser != null)
			{
				var browser = HtmlUILauncher.GetBrowser(e.Browser.Identifier);
				var handler = new EmbeddedResourceHandler(resourceAssembly, browser);
				e.SetReturnValue(handler);
			}




		}


	}
}
