namespace NanUIWebBrowserControlDemo
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.nanUIWebBrower1 = new NetDimension.NanUI.WebBrowserControl();
			this.SuspendLayout();
			// 
			// nanUIWebBrower1
			// 
			this.nanUIWebBrower1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nanUIWebBrower1.Location = new System.Drawing.Point(8, 8);
			this.nanUIWebBrower1.Name = "nanUIWebBrower1";
			this.nanUIWebBrower1.Size = new System.Drawing.Size(729, 387);
			this.nanUIWebBrower1.TabIndex = 1;
			this.nanUIWebBrower1.Text = "nanUIWebBrower1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 558);
			this.Controls.Add(this.nanUIWebBrower1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private NetDimension.NanUI.WebBrowserControl nanUIWebBrower1;
	}
}

