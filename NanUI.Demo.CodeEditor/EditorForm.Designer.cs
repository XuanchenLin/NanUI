namespace NanUI.Demo.CodeEditor
{
	partial class EditorForm
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
			this.SuspendLayout();
			// 
			// EditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.ClientSize = new System.Drawing.Size(778, 544);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "EditorForm";
			this.SplashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.SplashImage = global::NanUI.Demo.CodeEditor.Properties.Resources.CodeSpalsh;
			this.SplashImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Text = "NanUI 编辑器";
			this.ResumeLayout(false);

		}

		#endregion
	}
}

