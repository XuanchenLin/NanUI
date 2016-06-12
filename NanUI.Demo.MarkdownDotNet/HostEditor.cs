using Chromium;
using Chromium.Remote;
using NetDimension.NanUI.ChromiumCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NanUI.Demo.MarkdownDotNet
{
	class HostEditor : JSObject
	{
		frmMain MainFrame;
		internal HostEditor(frmMain main)
		{
			MainFrame = main;
			//暴露setCleanState方法到JS环境
			AddFunction("setCleanState").Execute += SetCleanState;
			//暴露newFile方法到JS环境
			AddFunction("newFile").Execute += NewFile;
			//暴露openFile方法到JS环境
			AddFunction("openFile").Execute += OpenFile;
			//暴露saveFile方法到JS环境
			AddFunction("saveFile").Execute += SaveFile;
		}

		/// <summary>
		/// 保存文档
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveFile(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			//从JS环境拿到第一个类型为String的参数，因为这个就是我们的文档
			var contents = e.Arguments.FirstOrDefault(p => p.IsString);
			var result = false;
			if (contents != null)
			{
				//调用主窗体的SaveFile方法来保存文档
				result = MainFrame.SaveFile(contents.StringValue);
			}

			if (result)
			{
				//如果保存成功就返回success状态，并返回保存文档的名称
				e.SetReturnValue(this.GetCfrObject(new
				{
					success = true,
					fileName = MainFrame.CurrentFile.Name
				}));
			}
			else
			{
				//如果保存失败就返回保存失败的状态
				e.SetReturnValue(this.GetCfrObject(new
				{
					success = false
				}));
			}
		}

		private void OpenFile(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{

			//打开文档的逻辑与保存文档的逻辑相似，这里就不再阐述
			
			var contents = e.Arguments.FirstOrDefault(p => p.IsString);
			string result = null;
			if (contents != null)
			{
				result = MainFrame.OpenFile(contents.StringValue);
			}

			if (!string.IsNullOrEmpty(result))
			{
				e.SetReturnValue(this.GetCfrObject(new
				{
					success = true,
					fileName = MainFrame.CurrentFile.Name,
					contents = result
				}));

			}
			else
			{
				e.SetReturnValue(this.GetCfrObject(new
				{
					success = false
				}));
			}
		}

		private void NewFile(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			//新建文档的逻辑与保存文档的逻辑相似，这里就不再阐述

			var contents = e.Arguments.FirstOrDefault(p => p.IsString);
			var result = false;
			result = MainFrame.NewFile(contents.StringValue);

			e.SetReturnValue(CfrV8Value.CreateBool(result));
		}

		private void SetCleanState(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			//从JS环境实时的回传当前CodeMirror中文档的修改状态来修改C#本地的文档状态。
			//如果文档被修改，再执行新建、打开等操作的时候提示用户先保存文档。
			if (e.Arguments.Length > 0 && e.Arguments[0].IsBool)
			{
				MainFrame.isClean = e.Arguments[0].BoolValue;
			}
		}
	}

	/// <summary>
	/// 匿名类转换成CfrObject的扩展方法，可以方便的将 new {...} 的类型转换成V8环境能够处理的CfrV8Value类型。
	/// </summary>
	public static class JSObjectExtension
	{
		public static CfrV8Value GetCfrObject(this JSObject _, object item)
		{

			var nameDict = new Dictionary<string, string>();

			var accessor = new CfrV8Accessor();

			var o = CfrV8Value.CreateObject(accessor);

			var t = item.GetType();

			foreach (var p in t.GetProperties())
			{
				var name = p.Name.Substring(0, 1).ToLower() + p.Name.Substring(1);

				nameDict[name] = p.Name;


				o.SetValue(name, CfxV8AccessControl.Default, CfxV8PropertyAttribute.DontDelete);
			}

			accessor.Get += (s, e) =>
			{
				var name = nameDict[e.Name];

				var p = t.GetProperty(name);

				var value = p.GetValue(item, null);
				var valueType = value?.GetType();





				if (value == null)
				{
					e.Retval = CfrV8Value.CreateNull();
				}
				else if (valueType == typeof(string) || valueType == typeof(Guid))
				{
					e.Retval = CfrV8Value.CreateString((string)value);
				}
				else if (valueType == typeof(int) || valueType == typeof(short) || valueType == typeof(long))
				{
					e.Retval = CfrV8Value.CreateInt((int)value);
				}
				else if (valueType == typeof(decimal))
				{
					e.Retval = CfrV8Value.CreateDouble(Convert.ToDouble(value));
				}
				else if (valueType == typeof(float) || valueType == typeof(double))
				{
					e.Retval = CfrV8Value.CreateDouble(Convert.ToDouble(value));
				}
				else if (valueType == typeof(bool))
				{
					e.Retval = CfrV8Value.CreateBool(Convert.ToBoolean(value));
				}
				else if (valueType == typeof(DateTime))
				{
					e.Retval = CfrV8Value.CreateDate(CfrTime.FromUniversalTime((DateTime)value));
				}
				else
				{
					e.Retval = CfrV8Value.CreateNull();
				}



				e.SetReturnValue(true);



			};


			return o;

		}

	}
}
