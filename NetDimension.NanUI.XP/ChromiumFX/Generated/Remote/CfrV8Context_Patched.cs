using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromium.Remote
{
	public partial class CfrV8Context
	{
		/// <summary>
		/// Execute a string of JavaScript code in this V8 context. The |scriptUrl|
		/// parameter is the URL where the script in question can be found, if any. The
		/// |startLine| parameter is the base line number to use for error reporting.
		/// On success |retval| will be set to the return value, if any, and the
		/// function will return true (1). On failure |exception| will be set to the
		/// exception, if any, and the function will return false (0).
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
		/// </remarks>
		public bool Eval(string code, string scriptUrl, int startLine, out CfrV8Value retval, out CfrV8Exception exception)
		{
			var call = new CfxV8ContextEvalRenderProcessCall();
			call.self = CfrObject.Unwrap(this);
			call.code = code;
			call.RequestExecution(this);
			retval = CfrV8Value.Wrap(call.retval);
			exception = CfrV8Exception.Wrap(call.exception);
			return call.__retval;
		}
	}
}
