using NetDimension.NanUI.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace NetDimension.NanUI
{
	public partial class RuntimeDownloadForm : Form
	{
		const int CS_DropSHADOW = 0x20000;
		string STR_DOWNLOADING = "正在下载必要的组件，请稍后...";

		string downloadUrl, runtimeDir;
		private RuntimeArch platformArch;
		private bool enableFlashSupport;

		private string cefVersion = string.Empty;

		private readonly string tmpPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "NanUIPackages");

		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;

				cp.ClassStyle |= CS_DropSHADOW;
				return cp;
			}
		}

		public RuntimeDownloadForm(string runtimeDir, string cefversion, string downloadUrl = null, RuntimeArch platformArch = RuntimeArch.x86, bool enableFlashSupport = false)
		{
			InitializeComponent();

			this.cefVersion = cefversion;

			this.platformArch = platformArch;
			this.enableFlashSupport = enableFlashSupport;
			if (string.IsNullOrEmpty(downloadUrl))
			{
				this.downloadUrl = "http://www.ohtrip.cn/nanui/";
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
		Dictionary<string, string> requirements = new Dictionary<string, string>()
		{
			["资源文件"] = "resources.exe"
		};

		int currentDonwloadItemIndex = 0;

		private void btnAutoDownload_Click(object sender, EventArgs e)
		{
			panel1.Visible = false;

			if (!prograssBar.Visible)
				prograssBar.Visible = true;




			if (platformArch == RuntimeArch.x86)
			{
				requirements["32位CEF运行时"] = "x86\\cef_x86.exe";
				if (enableFlashSupport)
				{
					requirements["32位Flash支持文件"] = "x86\\flash_x86.exe";
				}
			}
			else
			{
				requirements["64位CEF运行时"] = "x64\\cef_x64.exe";
				if (enableFlashSupport)
				{
					requirements["64位Flash支持文件"] = "x64\\flash_x64.exe";
				}
			}
			if (downloadUrl.Last() != '/')
			{
				downloadUrl += '/';
			}


			StartDownload(currentDonwloadItemIndex);


		}

		private void StartDownload(int index)
		{
			var currentTask = requirements.ElementAt(index);

			var count = requirements.Count;



			var baseUrl = $"{downloadUrl}NanUIPackages/{cefVersion}/";

			var url = $"{baseUrl}{currentTask.Value}";
			var tmpFile = new System.IO.FileInfo(System.IO.Path.Combine(tmpPath, currentTask.Value));

			if (!tmpFile.Directory.Exists)
			{
				tmpFile.Directory.Create();
			}

			var startTime = DateTime.Now;
			var webClient = new System.Net.WebClient();


			webClient.DownloadFileAsync(new Uri
	(url), tmpFile.FullName);


			webClient.DownloadProgressChanged += (s, args) =>
			{

				var tSpan = (DateTime.Now - startTime).TotalSeconds;
				var speed = (int)(args.BytesReceived / tSpan);
				prograssBar.Value = args.ProgressPercentage;
				lblInfo.Text = $"正在下载{currentTask.Key}，已完成{args.ProgressPercentage}%\r\n第{currentDonwloadItemIndex + 1}个共{requirements.Count}个\r\n（{ConverBytesToString(args.BytesReceived)}/{ConverBytesToString(args.TotalBytesToReceive)} {ConverBytesToString(speed)}/s）";
			};

			webClient.DownloadFileCompleted += (s, args) =>
			{
				if (args.Error != null)
				{
					MessageBox.Show(string.Format("下载失败，发生了下面的错误：\r\n{0}", args.Error.Message), "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.Close();
					return;
				}

				if (++currentDonwloadItemIndex < count)
				{
					StartDownload(currentDonwloadItemIndex);
					return;
				}

				lblInfo.Text = "下载完成，正在安装支持文件...";

				foreach (var file in requirements)
				{
					var filePath = System.IO.Path.Combine(tmpPath, file.Value);
					prograssBar.Visible = false;
					var info = new ProcessStartInfo(filePath)
					{
						CreateNoWindow = true,

					};

					lblInfo.Text = $"正在解压{file.Key}，请稍后...";



					var proc = Process.Start(info);
					proc.WaitForExit();

					var code = proc.ExitCode;
					proc.Close();
					proc.Dispose();



					if (code != 0)
					{
						MessageBox.Show(string.Format("安装CEF运行组件时发生了的错误：{0}", code), "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						return;
					}

				}

				this.DialogResult = DialogResult.OK;
			};
		}

		private void btnManualDownload_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/NetDimension/NanUI/#cef运行库下载");
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
