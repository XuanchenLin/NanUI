// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;
internal static class StringHelper
{
		public static bool IsNullOrEmpty(string value)
		{
			return value == null || value.Length == 0;
		}

		public static bool IsNullOrWhiteSpace(string value)
		{
			if (value == null) return true;

			for (int i = 0; i < value.Length; i++)
			{
				if (!char.IsWhiteSpace(value[i])) return false;
			}

			return true;
		}
}
