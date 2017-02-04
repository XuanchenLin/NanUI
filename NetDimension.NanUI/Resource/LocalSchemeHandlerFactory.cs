using Chromium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Resource
{
	internal class LocalSchemeHandlerFactory : CfxSchemeHandlerFactory
	{
        public string SchemeName
        {
            get;
            private set;
        }

        internal LocalSchemeHandlerFactory(string schemeName)
		{
            this.SchemeName = schemeName;
			this.Create += LocalSchemeHandlerFactory_Create;
		}

		private void LocalSchemeHandlerFactory_Create(object sender, Chromium.Event.CfxSchemeHandlerFactoryCreateEventArgs e)
		{
            if (e.SchemeName == SchemeName && e.Browser != null)
            //if (e.SchemeName.Equals("local") && e.Browser != null)
			{
				var browser = HtmlUILauncher.GetBrowser(e.Browser.Identifier);
				var handler = new LocalResourceHandler(browser);
				e.SetReturnValue(handler);
			}
		}
	}
}
