# Welcome to NanUI
**What's NanUI**

NanUI is a .NET Winform UI which can be design by HTML5, CSS3 and Javascripts. It's base on open source project Chromium Embedded Framework(CEF) and ChromiumFX.

**How to use**

1. Add Reference of the ``NetDimension.NanUI.dll`` to your project.
2. Modify ``Main`` as below.

        static void Main()
        {
        	Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// Initialize the Chromium.
       		if (HtmlUILauncher.InitializeChromium())
			{
				//if intialization is successful, start the MainForm.
				Application.Run(new frmMain());
			}
        }

3. Let MainForm inherit from ``UIHtmlForm`` class, and set a startup URL.

		public class frmMain : HtmlUIForm
        {
            public frmMain()
            	: base("http://www.google.com")
            {
                // Initialize form components...
            }
        }
    
After that, Let your Winform rock. You can now design your form with HTML.