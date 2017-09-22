using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Chromium;
using Chromium.WebBrowser;

namespace NetDimension.NanUI.ResourceHandler
{
	class AssemblyResourceHandler : CfxResourceHandler
	{
		private int readResponseStreamOffset;
		private readonly Assembly resourceAssembly;

		private string requestUrl = null;

		private WebResource webResource;
		private BrowserCore browser;

		private GCHandle gcHandle;

		private string domain = null;


		internal AssemblyResourceHandler(Assembly resourceAssembly, BrowserCore browser, string domain)
		{
			gcHandle = GCHandle.Alloc(this);

			this.domain = domain;
			this.browser = browser;
			this.resourceAssembly = resourceAssembly;
			this.GetResponseHeaders += OnGetResponseHeaders;
			this.ProcessRequest += OnProcessRequest;
			this.ReadResponse += OnReadResponse;
			this.CanGetCookie += (_, e) => e.SetReturnValue(false);
			this.CanSetCookie += (_, e) => e.SetReturnValue(false);

		}
		private void OnGetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
		{
			if (webResource == null)
			{
				e.Response.Status = 404;
			}
			else
			{
				e.ResponseLength = webResource.data.Length;
				e.Response.MimeType = webResource.mimeType;
				e.Response.Status = 200;

				if (!browser.webResources.ContainsKey(requestUrl))
				{
					browser.SetWebResource(requestUrl, webResource);
				}
			}
		}

		private void OnProcessRequest(object sender, Chromium.Event.CfxProcessRequestEventArgs e)
		{
			readResponseStreamOffset = 0;
			var request = e.Request;
			var callback = e.Callback;

			var uri = new Uri(request.Url);

			requestUrl = request.Url;

			var fileName = string.IsNullOrEmpty(domain) ? string.Format("{0}{1}", uri.Authority, uri.AbsolutePath) : uri.AbsolutePath;

			if (fileName.StartsWith("/") && fileName.Length > 1)
			{
				fileName = fileName.Substring(1);
			}

			var ass = resourceAssembly;
			var endTrimIndex = fileName.LastIndexOf('/');

			if (endTrimIndex > -1)
			{
				var tmp = fileName.Substring(0, endTrimIndex);
				tmp = tmp.Replace("-", "_");

				fileName = string.Format("{0}{1}", tmp, fileName.Substring(endTrimIndex));
			}

			var resourcePath = string.Format("{0}.{1}", ass.GetName().Name, fileName.Replace('/', '.'));






			var resourceName = ass.GetManifestResourceNames().SingleOrDefault(p => p.Equals(resourcePath, StringComparison.CurrentCultureIgnoreCase));

			if (!string.IsNullOrEmpty(resourceName) && ass.GetManifestResourceInfo(resourceName) != null)
			{
				using (var reader = new System.IO.BinaryReader(ass.GetManifestResourceStream(resourceName)))
				{
					var buff = reader.ReadBytes((int)reader.BaseStream.Length);

					webResource = new WebResource(buff, CfxRuntime.GetMimeType(System.IO.Path.GetExtension(fileName).TrimStart('.')));

					reader.Close();

					if (!browser.webResources.ContainsKey(requestUrl))
					{
						browser.SetWebResource(requestUrl, webResource);
					}
				}
				
				//Console.WriteLine($"[加载嵌入资源]:\t{requestUrl}");

				callback.Continue();
				e.SetReturnValue(true);
			}
			else
			{
				Console.WriteLine($"[错误嵌入资源]:\t{requestUrl}");
				callback.Continue();
				e.SetReturnValue(false);
			}



		}
		private void OnReadResponse(object sender, Chromium.Event.CfxReadResponseEventArgs e)
		{
			int bytesToCopy = webResource.data.Length - readResponseStreamOffset;
			if (bytesToCopy > e.BytesToRead)
				bytesToCopy = e.BytesToRead;
			Marshal.Copy(webResource.data, readResponseStreamOffset, e.DataOut, bytesToCopy);
			e.BytesRead = bytesToCopy;
			readResponseStreamOffset += bytesToCopy;
			e.SetReturnValue(true);


			if (readResponseStreamOffset == webResource.data.Length)
			{
				gcHandle.Free();
				Console.WriteLine($"[加载嵌入资源]:\t{requestUrl}");
				
			}

		}




	}
}
