using Chromium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Resource
{
	internal class LocalResourceHandler : CfxResourceHandler
	{
		private int readResponseStreamOffset;

		string requestFile = null;

		string requestUrl = null;

		private WebResource webResource;
		private IChromiumWebBrowser browser;


		private System.Runtime.InteropServices.GCHandle gcHandle;

		internal LocalResourceHandler(IChromiumWebBrowser browser)
		{
			gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(this);


			this.browser = browser;

			this.GetResponseHeaders += LocalResourceHandler_GetResponseHeaders;
			this.ProcessRequest += LocalResourceHandler_ProcessRequest;
			this.ReadResponse += LocalResourceHandler_ReadResponse;
			this.CanGetCookie += (s, e) => e.SetReturnValue(false);
			this.CanSetCookie += (s, e) => e.SetReturnValue(false);

		}

		private void LocalResourceHandler_ProcessRequest(object sender, Chromium.Event.CfxProcessRequestEventArgs e)
		{

			readResponseStreamOffset = 0;
			var request = e.Request;
			var callback = e.Callback;

			var uri = new Uri(request.Url);

			requestUrl = request.Url;
			var localPath = uri.LocalPath;
			if (localPath.StartsWith("/"))
				localPath = $".{localPath}";

			var fileName = System.IO.Path.GetFullPath(localPath);


			requestFile = request.Url;


			if (System.IO.File.Exists(fileName))
			{
				using (var stream = System.IO.File.OpenRead(fileName))
				using (var reader = new System.IO.BinaryReader(stream))
				{
					var buff = reader.ReadBytes((int)reader.BaseStream.Length);
					webResource = new WebResource(buff, MimeHelper.GetMimeType(System.IO.Path.GetExtension(fileName)));

					reader.Close();
					stream.Close();
				}

				Console.WriteLine($"[加载]:\t{requestUrl}\t->\t{fileName}");
			}
			else
			{
				Console.WriteLine($"[未找到]:\t{requestUrl}");
			}

			callback.Continue();
			e.SetReturnValue(true);

		}

		private void LocalResourceHandler_GetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
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


		private void LocalResourceHandler_ReadResponse(object sender, Chromium.Event.CfxReadResponseEventArgs e)
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
				Console.WriteLine($"[完成]:\t{requestUrl}");
			}
		}
	}
}
