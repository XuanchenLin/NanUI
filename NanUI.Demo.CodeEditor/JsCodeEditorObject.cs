using System.Linq;

namespace NanUI.Demo.CodeEditor
{
	using Chromium.Remote;
	using NetDimension.NanUI.ChromiumCore;
	class JsCodeEditorObject : JSObject
	{

		EditorForm parentForm;
		
		internal JsCodeEditorObject(EditorForm parentForm)
		{
			this.parentForm = parentForm;
			
			AddFunction("newFile").Execute += JsCodeEditorObject_ExecuteNew;

			AddFunction("openFile").Execute += JsCodeEditorObject_ExecuteOpen;

			AddFunction("saveFile").Execute += JsCodeEditorObject_ExecuteSave;

			AddFunction("setClean").Execute += JsCodeEditorObject_ExecuteSetClean;

			AddFunction("showDevTools").Execute += ShowDevTools;

			AddFunction("showAbout").Execute += ShowAboutForm;

		}

		private void ShowDevTools(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			parentForm.ShowDevTools();
		}

		private void ShowAboutForm(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			parentForm.ShowAboutNanUI();
		}

		private void JsCodeEditorObject_ExecuteSetClean(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			if (e.Arguments.Length > 0)
			{

				parentForm.isClean = e.Arguments.First(p => p.IsBool).BoolValue;
			}
		}

		private void JsCodeEditorObject_ExecuteSave(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			var result  = parentForm.SaveFile();

			e.SetReturnValue(CfrV8Value.CreateBool(result));

		}

		private void JsCodeEditorObject_ExecuteOpen(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			var result = parentForm.OpenFile();

			if (result != null)
			{
				e.SetReturnValue(CfrV8Value.CreateString(result));

			}
			else
			{
				e.SetReturnValue(CfrV8Value.CreateNull());
			}
		}

		private void JsCodeEditorObject_ExecuteNew(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			parentForm.NewFile();
		}
	}
}
