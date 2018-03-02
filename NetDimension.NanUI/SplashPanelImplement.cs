using Chromium.WebBrowser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public interface ISplashPanel
	{
		Panel SplashPanel { get; }
		Image SplashImage { get; set; }
		ImageLayout SplashImageLayout { get; set; }
		Color SplashPanelColor { get; set; }

		//void ShowSplash();
		//void HideSplash();

	}
	internal class SplashPanelImplement : ISplashPanel
	{
		private readonly Panel splashPanel = new Panel(){ Dock = DockStyle.Fill, BackColor = Color.Transparent };

		Form parentForm;
		BrowserCore browserCore;

		public Panel SplashPanel
		{
			get
			{
				return splashPanel;
			}
		}
		
		public Image SplashImage { get => splashPanel.BackgroundImage; set => splashPanel.BackgroundImage = value; }
		public ImageLayout SplashImageLayout { get => splashPanel.BackgroundImageLayout; set => splashPanel.BackgroundImageLayout = value; }
		public Color SplashPanelColor { get => splashPanel.BackColor; set => splashPanel.BackColor = value; }
		
		public SplashPanelImplement(Form form, BrowserCore browser)
		{
			this.parentForm = form;
			this.browserCore = browser;

			form.Controls.Add(splashPanel);
			splashPanel.BringToFront();


			if (BrowserProcess.initialized)
			{
				browser.LoadHandler.OnLoadEnd += (_, args) =>
				{
					if (args.Frame.IsMain)
					{
						HideSplash();
					}
				};
			}



			ShowSplash();

		}

		public void ShowSplash()
		{
			parentForm.RequireUIThread(() =>
			{
				splashPanel.Visible = true;
				splashPanel.BringToFront();
			});
		}
		public void HideSplash()
		{
			parentForm.RequireUIThread(() =>
			{
				splashPanel.Visible = false;
				splashPanel.SendToBack();
			});
		}


	}
}
