using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI;
using System.Runtime.InteropServices;

namespace NanUI.Demo.WidgetWindow
{
	public partial class Form1 : HtmlWidgetForm
	{

		public Form1() : base("www.ohtrip.cn/nanui/widget/index.html")
		{
			InitializeComponent();
			Width = 400;
			Height = 500;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Capture = false;
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);          //<-------
			}
			else
			{
				this.Close();          // 右键可以退出
			}
		}

		const int WM_NCLBUTTONDOWN = 0xA1;
		const int HT_CAPTION = 0x2;
		[DllImport("user32.dll")]
		static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


	}
}
