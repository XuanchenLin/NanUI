// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chromium.WebBrowser {
	class CefException : Exception {
		internal CefException(string message) : base(message) { }
	}
}


namespace NetDimension.NanUI
{
	using Chromium.WebBrowser;
	class NanUIException : CefException
	{
		internal NanUIException(string message) : base(message) { }
	}
}