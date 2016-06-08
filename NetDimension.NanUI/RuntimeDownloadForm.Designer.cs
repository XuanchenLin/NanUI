namespace NetDimension.NanUI
{
	partial class RuntimeDownloadForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuntimeDownloadForm));
			this.prograssBar = new System.Windows.Forms.ProgressBar();
			this.lblInfo = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAutoDownload = new System.Windows.Forms.Button();
			this.btnManualDownload = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// prograssBar
			// 
			this.prograssBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prograssBar.Location = new System.Drawing.Point(35, 150);
			this.prograssBar.Name = "prograssBar";
			this.prograssBar.Size = new System.Drawing.Size(410, 25);
			this.prograssBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.prograssBar.TabIndex = 0;
			this.prograssBar.Visible = false;
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfo.ForeColor = System.Drawing.Color.Gray;
			this.lblInfo.Location = new System.Drawing.Point(35, 185);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(410, 100);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnManualDownload);
			this.panel1.Controls.Add(this.btnAutoDownload);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(35, 150);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(410, 135);
			this.panel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(410, 78);
			this.label1.TabIndex = 0;
			this.label1.Text = "本软件基于开源项目Chromium Embedded Framework，但系统中没有检测到CEF运行框架。如需继续运行，请下载并安装CEF运行框架。";
			// 
			// btnAutoDownload
			// 
			this.btnAutoDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutoDownload.Location = new System.Drawing.Point(125, 107);
			this.btnAutoDownload.Name = "btnAutoDownload";
			this.btnAutoDownload.Size = new System.Drawing.Size(90, 25);
			this.btnAutoDownload.TabIndex = 1;
			this.btnAutoDownload.Text = "自动下载";
			this.btnAutoDownload.UseVisualStyleBackColor = true;
			this.btnAutoDownload.Click += new System.EventHandler(this.btnAutoDownload_Click);
			// 
			// btnManualDownload
			// 
			this.btnManualDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnManualDownload.Location = new System.Drawing.Point(221, 107);
			this.btnManualDownload.Name = "btnManualDownload";
			this.btnManualDownload.Size = new System.Drawing.Size(90, 25);
			this.btnManualDownload.TabIndex = 2;
			this.btnManualDownload.Text = "手动下载";
			this.btnManualDownload.UseVisualStyleBackColor = true;
			this.btnManualDownload.Click += new System.EventHandler(this.btnManualDownload_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(317, 107);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 25);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// RuntimeDownloadForm
			// 
			this.AcceptButton = this.btnAutoDownload;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(480, 320);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.prograssBar);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RuntimeDownloadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NanUI 界面支持";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar prograssBar;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnManualDownload;
		private System.Windows.Forms.Button btnAutoDownload;
		private System.Windows.Forms.Label label1;
	}
}