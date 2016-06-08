using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanUI.Demo.CodeEditor.Resources
{
	public static class SchemeHelper
	{
		public static System.Reflection.Assembly GetSchemeAssembley()
		{
			return System.Reflection.Assembly.GetExecutingAssembly();
		}
	}
}
