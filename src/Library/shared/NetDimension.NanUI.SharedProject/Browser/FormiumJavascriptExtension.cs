using Chromium;
using Chromium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    internal sealed class FormiumJavascriptExtension : ChromiumExtensionBase
    {
        static string version;
        static string cefVersion;
        static string chromiumVersion;

        public FormiumJavascriptExtension()
        {
            
        }

        public override string DefinitionJavascriptCode => Properties.Resources.NanUIExtension;

        public override CfrV8Value OnExtensionExecute(string nativeFunctionName, CfrV8Value[] arguments, CfrV8Value @this, ref string exception)
        {
            CfrV8Value retval = null;

            Console.WriteLine($"[FUNC]:{nativeFunctionName}");

            switch (nativeFunctionName)
            {
                case nameof(Version):
                    var accessor = new CfrV8Accessor();
                    
                    var versionObject = CfrV8Value.CreateObject(accessor);
                    
                    versionObject.SetValue("nanui", CfrV8Value.CreateString(Version), CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);
                    versionObject.SetValue("cef", CfrV8Value.CreateString(CefVersion), CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);
                    versionObject.SetValue("chromium", CfrV8Value.CreateString(ChromiumVersion), CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);



                    retval = versionObject;

                    break;

            }
            return retval;
        }


        public string Version {
            get
            {
                if (string.IsNullOrEmpty(version))
                {
                    version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                }

                return version;
            }
        }

        public string CefVersion
        {
            get
            {
                if (string.IsNullOrEmpty(cefVersion))
                {
                    cefVersion = CfxRuntime.GetCefVersion();

                }

                return cefVersion;
            }
        }

        public string ChromiumVersion
        {
            get
            {
                if (string.IsNullOrEmpty(chromiumVersion))
                {
                    chromiumVersion = CfxRuntime.GetChromeVersion();

                }

                return chromiumVersion;
            }
        }

       


    }
}
