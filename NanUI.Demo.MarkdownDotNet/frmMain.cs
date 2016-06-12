using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NanUI.Demo.MarkdownDotNet
{
	public partial class frmMain : HtmlUIForm
	{


		public frmMain()
			: base("res://assets/main.html")
		{
			InitializeComponent();

			GlobalObject.Add("hostEditor", new HostEditor(this));

			LoadHandler.OnLoadStart += (s, e) =>
			{

				if (e.Frame.IsMain)
				{
					//ShowDevTools();
				}
			};
		}
		/// <summary>
		/// 标记文档是否被修改
		/// </summary>
		internal bool isClean = true;
		/// <summary>
		/// 当前文档的存储路径，如果为空则说明该文档是新文档
		/// </summary>
		internal string currentFilePath = string.Empty;

		/// <summary>
		/// 当前文档的FileInfo
		/// </summary>
		internal System.IO.FileInfo CurrentFile
		{
			get
			{
				return new System.IO.FileInfo(currentFilePath);
			}
		}

		/// <summary>
		/// 获得一个标识当前文档是否为新建文档
		/// </summary>
		private bool IsNewFile
		{
			get
			{
				return string.IsNullOrEmpty(currentFilePath);
			}
		}
		/// <summary>
		/// 新建文件
		/// </summary>
		/// <param name="contents">当前文档中的内容</param>
		/// <returns>如果新建成功则返回true</returns>
		internal bool NewFile(string contents)
		{
			var continueFlag = true;


			if (!isClean)
			{
				var ret = MessageBox.Show(this, "文件已经更改，是否保存下先？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (ret == DialogResult.Yes)
				{
					if (!SaveFile(contents))
					{
						continueFlag = false;
					}
				}
				else if (ret == DialogResult.Cancel)
				{
					continueFlag = false;
				}

			}

			if (!continueFlag)
			{
				return false;
			}

			currentFilePath = null;
			isClean = true;


			return true;
		}
		/// <summary>
		/// 打开文档
		/// </summary>
		/// <param name="contents">当前文档中的内容</param>
		/// <returns>如果新建成功则返回打开文档的内容</returns>
		internal string OpenFile(string contents)
		{
			var continueFlag = true;
			if (!isClean)
			{
				var ret = MessageBox.Show(this, "文件已经更改，是否保存下先？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (ret == DialogResult.Yes)
				{
					if (!SaveFile(contents))
					{
						continueFlag = false;
					}
				}
				else if (ret == DialogResult.Cancel)
				{
					continueFlag = false;
				}

			}

			if (!continueFlag)
			{
				return null;
			}

			var content = string.Empty;

			var openDialog = new OpenFileDialog()
			{
				AddExtension = true,
				Filter = "Markdown文件|*.md"
			};

			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				currentFilePath = openDialog.FileName;

				var fileInfo = new System.IO.FileInfo(currentFilePath);

				content = System.IO.File.ReadAllText(fileInfo.FullName);

			}
			else
			{
				content = null;
			}

			return content;


		}
		/// <summary>
		/// 保存文档
		/// </summary>
		/// <param name="contents">当前文档中的内容</param>
		/// <returns>如果保存成功则返回true</returns>
		internal bool SaveFile(string contents) {

			if (!IsNewFile) {
				if (isClean) return true;


				System.IO.File.WriteAllText(currentFilePath, contents, Encoding.UTF8);
				isClean = true;
				return true;
			}


			var saveFileDialog = new SaveFileDialog()
			{
				AddExtension = true,
				Filter = "Markdown文件|*.md",
				OverwritePrompt = true
			};

			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				currentFilePath = saveFileDialog.FileName;

				System.IO.File.WriteAllText(currentFilePath, contents, Encoding.UTF8);

				isClean = true;

				return true;
			}

			return false;

		}
	}
}
