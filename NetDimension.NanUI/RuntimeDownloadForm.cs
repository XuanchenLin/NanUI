using Chromium;
using NetDimension.NanUI.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NetDimension.NanUI
{
	public partial class RuntimeDownloadForm : Form
	{
		const int CS_DropSHADOW = 0x20000;
		string STR_DOWNLOADING = "正在下载必要的组件，请稍后...";

		string downloadUrl, runtimeDir;
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;

				cp.ClassStyle |= CS_DropSHADOW;
				return cp;
			}
		}

		public RuntimeDownloadForm(string runtimeDir, string downloadUrl = null)
		{
			InitializeComponent();

			if (string.IsNullOrEmpty(downloadUrl))
			{
				this.downloadUrl = "http://www.bolepa.com/nanui/";
			}
			else
			{
				this.downloadUrl = downloadUrl;
			}
			this.runtimeDir = runtimeDir;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lblInfo.Text = STR_DOWNLOADING;
		}



		private string ConverBytesToString(long length)
		{
			string x = null;

			if (length >= 1024 * 1024)
			{
				x = string.Format("{0:#.0} MB", length / 1024m / 1024m);
			}
			else if (length >= 1024)
			{
				x = string.Format("{0:#} KB", length / 1024m);
			}
			else
			{
				x = string.Format("{0:0} 字节", length);
			}

			return x;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAutoDownload_Click(object sender, EventArgs e)
		{
			panel1.Visible = false;

			var webClient = new System.Net.WebClient();
			var startTime = DateTime.Now;
			if (!prograssBar.Visible)
				prograssBar.Visible = true;

			var tmpFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "CEFRuntime.exe");


			webClient.DownloadProgressChanged += (s, args) =>
			{


				var tSpan = (DateTime.Now - startTime).TotalSeconds;
				var speed = (int)(args.BytesReceived / tSpan);
				prograssBar.Value = args.ProgressPercentage;
				lblInfo.Text = string.Format("正在下载CEF运行组件，已完成{0}%\r\n（{1}/{2} {3}/s）", args.ProgressPercentage, ConverBytesToString(args.BytesReceived), ConverBytesToString(args.TotalBytesToReceive), ConverBytesToString(speed));
			};

			webClient.DownloadFileCompleted += (s, args) =>
			{
				if (args.Error == null)
				{
					prograssBar.Visible = false;
					lblInfo.Text = "下载完成，正在安装。。。";
					var info = new ProcessStartInfo(tmpFile)
					{
						CreateNoWindow = true
					};
					var proc = Process.Start(info);
					proc.WaitForExit();

					var code = proc.ExitCode;

					if (code == 0)
					{
						this.DialogResult = DialogResult.OK;
						lblInfo.Text = "安装完成！";
					}
					else
					{
						MessageBox.Show(string.Format("安装CEF运行组件时发生了的错误：{0}", code), "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

					proc.Close();
					proc.Dispose();


					this.Close();
				}
				else
				{
					MessageBox.Show(string.Format("下载失败，发生了下面的错误：\r\n{0}", args.Error.Message), "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.Close();
				}
			};
			webClient.DownloadFileAsync(new Uri
				(downloadUrl+"CEFRuntime.exe"), tmpFile);
		}

		private void btnManualDownload_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.bolepa.com/nanui/");
			this.Close();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			NativeMethods.ReleaseCapture();
			NativeMethods.SendMessage(Handle, NativeMethods.WindowsMessage.WM_NCLBUTTONDOWN, (IntPtr)NativeMethods.HitTest.HTCAPTION, (IntPtr)0);
		}
	}
}
