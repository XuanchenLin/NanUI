using System.Text;
using System.Windows.Forms;

namespace NanUI.Demo.CodeEditor
{
	using NetDimension.NanUI;

	public partial class EditorForm : HtmlUIForm
	{

		internal bool isClean = true;
		internal bool isNew = true;

		internal string currentFilePath = string.Empty;

		//NanUI窗口会自动检测是否运行在XP下面。
		//在XP环境下DWM自动禁用，NanUI改为重绘Nonclient Area的方式来进行窗口绘制。
		//当然，也可以在Win7等支持DWM的系统中禁用DWM窗口绘制，如下，构造第二个参数设置为true
		//将强制窗口使用Nanclient区域重绘。
		public EditorForm()
			: base("http://www/main.html")
		{
			InitializeComponent();




			GlobalObject.Add("hostEditor", new JsCodeEditorObject(this));
		}

		void SetEditorMode()
		{
			if (!string.IsNullOrEmpty(currentFilePath))
			{
				var fileInfo = new System.IO.FileInfo(currentFilePath);

				var ext = fileInfo.Extension;

				if (ext.IndexOf('.') == 0)
				{
					ext = ext.Substring(1);
					ExecuteJavascript($"CodeEditor.changeCodeScheme('{ext}');");
				}
			}
		}

		//设置编辑器标题逻辑
		void SetEditorTitle()
		{
			if (isNew || string.IsNullOrEmpty(currentFilePath))
			{
				ExecuteJavascript($"CodeEditor.setTitle('新建');");
			}
			else
			{
				var fileInfo = new System.IO.FileInfo(currentFilePath);
				ExecuteJavascript($"CodeEditor.setTitle('{fileInfo.Name}');");
			}
		}
		//保存文件逻辑
		internal bool SaveFile()
		{
			var result = false;
			EvaluateJavascript(@"CodeEditor.getContent()", (value, ex) =>
			{
				if (ex == null)
				{
					var content = value.IsString ? value.StringValue : null;

					if (content != null)
					{

						if (isNew)
						{
							var saveFileDialog = new SaveFileDialog()
							{
								AddExtension = true,
								Filter = "支持的文件|*.txt;*.js;*.cs;*.html;*.htm;*.css;*.h;*.cpp;*.php;*.xml;*.vb",
								OverwritePrompt = true
							};
							if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
							{
								currentFilePath = saveFileDialog.FileName;
								result = true;

							}
						}

						if (result)
						{
							System.IO.File.WriteAllText(currentFilePath, content, Encoding.UTF8);
							isClean = true;
							SetEditorMode();
							SetEditorTitle();
						}



					}
				}
			});

			return result;
		}
		//新建文件逻辑
		internal void NewFile()
		{
			var continueFlag = true;

			if (!isClean)
			{
				var ret = MessageBox.Show(this, "文件已经更改，是否保存下先？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (ret == DialogResult.Yes)
				{
					if (!SaveFile())
					{
						continueFlag = false;
					}
				}
				else if (ret == DialogResult.Cancel)
				{
					return;
				}
			}

			if (!continueFlag)
			{
				return;
			}

			isNew = true;
			isClean = true;


			ExecuteJavascript(@"CodeEditor.setNew()");
			SetEditorTitle();



		}
		//打开文件逻辑
		internal string OpenFile()
		{
			var continueFlag = true;

			if (!isClean)
			{
				var ret = MessageBox.Show(this, "文件已经更改，是否保存下先？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (ret == DialogResult.Yes)
				{
					if (!SaveFile())
					{
						continueFlag = false;
					}
				}
				else if (ret == DialogResult.Cancel)
				{
					return null;
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
				Filter = "支持的文件|*.txt;*.js;*.cs;*.html;*.htm;*.css;*.h;*.cpp;*.php;*.xml;*.vb"
			};

			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				currentFilePath = openDialog.FileName;

				var fileInfo = new System.IO.FileInfo(currentFilePath);

				content = System.IO.File.ReadAllText(fileInfo.FullName);

				isNew = false;

				SetEditorMode();
				SetEditorTitle();
			}
			else
			{
				content = null;
			}

			return content;
		}
	}
}
