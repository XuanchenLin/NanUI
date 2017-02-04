using Chromium;
using System;
using System.Linq;
using System.Reflection;

namespace NetDimension.NanUI.Resource
{
	internal class EmbeddedResourceHandler : CfxResourceHandler
	{

		private int readResponseStreamOffset;
		private Assembly resourceAssembly;

		string requestFile = null;

		string requestUrl = null;

		private WebResource webResource;
		private IChromiumWebBrowser browser;

		private System.Runtime.InteropServices.GCHandle gcHandle;
		internal EmbeddedResourceHandler(Assembly resourceAssembly, IChromiumWebBrowser browser)
		{
			gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(this);


			this.browser = browser;

			this.resourceAssembly = resourceAssembly;
			this.GetResponseHeaders += EmbeddedResourceHandler_GetResponseHeaders;
			this.ProcessRequest += EmbeddedResourceHandler_ProcessRequest;
			this.ReadResponse += EmbeddedResourceHandler_ReadResponse;
			this.CanGetCookie += (s, e) => e.SetReturnValue(false);
			this.CanSetCookie += (s, e) => e.SetReturnValue(false);
		}


		private void EmbeddedResourceHandler_ProcessRequest(object sender, Chromium.Event.CfxProcessRequestEventArgs e)
		{

			readResponseStreamOffset = 0;
			var request = e.Request;
			var callback = e.Callback;

			var uri = new Uri(request.Url);

			requestUrl = request.Url;

			var fileName = string.Format("{0}{1}", uri.Authority, uri.AbsolutePath);

			requestFile = uri.AbsolutePath;

			var ass = resourceAssembly;
			var resourcePath = string.Format("{0}.{1}", ass.GetName().Name, fileName.Replace('/', '.'));
			var resourceName = ass.GetManifestResourceNames().SingleOrDefault(p => p.Equals(resourcePath, StringComparison.CurrentCultureIgnoreCase));

			if (!string.IsNullOrEmpty(resourceName) && ass.GetManifestResourceInfo(resourceName) != null)
			{
				using (var reader = new System.IO.BinaryReader(ass.GetManifestResourceStream(resourceName)))
				{
					var buff = reader.ReadBytes((int)reader.BaseStream.Length);

					webResource = new WebResource(buff, MimeHelper.GetMimeType(System.IO.Path.GetExtension(fileName)));

					reader.Close();

					if (!browser.WebResources.ContainsKey(requestUrl))
					{
						browser.SetWebResource(requestUrl, webResource);
					}
				}


                //Console.WriteLine($"[加载]:\t{requestUrl}");
                Console.WriteLine(string.Format("[加载]:\t{0}",requestUrl));



			}
			else
			{
                //Console.WriteLine($"[未找到]:\t{requestUrl}");
                Console.WriteLine(string.Format("[未找到]:\t{0}",requestUrl));
			}


			callback.Continue();
			e.SetReturnValue(true);

		}

		private void EmbeddedResourceHandler_GetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
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

				if (!browser.WebResources.ContainsKey(requestUrl))
				{
					browser.SetWebResource(requestUrl, webResource);
				}

			}

		}


		private void EmbeddedResourceHandler_ReadResponse(object sender, Chromium.Event.CfxReadResponseEventArgs e)
		{
			int bytesToCopy = webResource.data.Length - readResponseStreamOffset;
			if (bytesToCopy > e.BytesToRead)
				bytesToCopy = e.BytesToRead;
			System.Runtime.InteropServices.Marshal.Copy(webResource.data, readResponseStreamOffset, e.DataOut, bytesToCopy);
			e.BytesRead = bytesToCopy;
			readResponseStreamOffset += bytesToCopy;
			e.SetReturnValue(true);


			if (readResponseStreamOffset == webResource.data.Length)
			{
				gcHandle.Free();
                //Console.WriteLine($"[完成]:\t{requestUrl}");
                Console.WriteLine(string.Format("[完成]:\t{0}",requestUrl));
			}
		}
	}
}
