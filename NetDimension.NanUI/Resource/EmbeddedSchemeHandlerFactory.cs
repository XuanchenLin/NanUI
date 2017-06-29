using Chromium;
using System;
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

		public string DomainName
		{
			get;
			private set;
		}

		private readonly Assembly resourceAssembly;

		internal EmbeddedSchemeHandlerFactory(string schemeName, string domainName, Assembly resourceAssembly)
		{



			this.resourceAssembly = resourceAssembly;
			this.SchemeName = schemeName;

			this.DomainName = domainName;

			this.Create += EmbeddedSchemeHandlerFactory_Create;
		}

		private void EmbeddedSchemeHandlerFactory_Create(object sender, Chromium.Event.CfxSchemeHandlerFactoryCreateEventArgs e)
		{

			//var url = new Uri(e.Request.Url);

			if (e.SchemeName == SchemeName && e.Browser != null)
			{
				var browser = HtmlUILauncher.GetBrowser(e.Browser.Identifier);
				var handler = new EmbeddedResourceHandler(resourceAssembly, browser, DomainName);
				e.SetReturnValue(handler);
			}




		}


	}
}
