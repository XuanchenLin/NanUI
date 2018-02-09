
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.SchemeHandler
{
	using Chromium;
	using Chromium.WebBrowser;
	using System.Runtime.InteropServices;

	class FolderResourceHandler : CfxResourceHandler
	{
		private int readResponseStreamOffset;
		private string requestUrl = null;
		private readonly string basePath;

		private WebResource webResource;
		private BrowserCore browser;

		private string physicalPath = null;

		private GCHandle gcHandle;

		private string domain = null;

		private int? buffStartPostition = null;
		private int? buffEndPostition = null;
		private bool isPartContent = false;


		internal FolderResourceHandler(string assertPath, BrowserCore browser, string domain)
		{
			gcHandle = GCHandle.Alloc(this);
			this.domain = domain;
			this.browser = browser;
			this.basePath = assertPath;
			this.GetResponseHeaders += OnGetResponseHeaders;
			this.ProcessRequest += OnProcessRequest;
			this.ReadResponse += OnReadResponse;
			this.CanGetCookie += (_, e) => e.SetReturnValue(false);
			this.CanSetCookie += (_, e) => e.SetReturnValue(false);


		}

		private void OnProcessRequest(object sender, Chromium.Event.CfxProcessRequestEventArgs e)
		{
			var request = e.Request;
			var callback = e.Callback;

			var uri = new Uri(request.Url);
			requestUrl = request.Url;

			var headers = request.GetHeaderMap().Select(x => new { Key = x[0], Value = x[1] }).ToList();

			var contentRange = headers.FirstOrDefault(x => x.Key.ToLower() == "range");

			if (contentRange != null)
			{
				var group = System.Text.RegularExpressions.Regex.Match(contentRange.Value, @"(?<start>\d+)-(?<end>\d*)")?.Groups;
				if (group != null)
				{
					if (!string.IsNullOrEmpty(group["start"].Value) && int.TryParse(group["start"].Value, out int startPos))
					{
						buffStartPostition = startPos;
					}

					if (!string.IsNullOrEmpty(group["end"].Value) && int.TryParse(group["end"].Value, out int endPos))
					{
						buffEndPostition = endPos;
					}
				}

				isPartContent = true;

			}

			readResponseStreamOffset = 0;


			readResponseStreamOffset = 0;

			if (buffStartPostition.HasValue)
			{
				readResponseStreamOffset = buffStartPostition.Value;
			}

			var fileName =  string.IsNullOrEmpty(domain) ? string.Format("{0}{1}", uri.Authority, Uri.UnescapeDataString(uri.AbsolutePath)) : Uri.UnescapeDataString(uri.AbsolutePath);

			

			if (fileName.StartsWith("/") && fileName.Length > 1)
			{
				fileName = fileName.Substring(1);
			}

			var endTrimIndex = fileName.LastIndexOf('/');

			if (endTrimIndex > -1)
			{
				var tmp = fileName.Substring(0, endTrimIndex);
				tmp = tmp.Replace("-", "_");

				fileName = string.Format("{0}{1}", tmp, fileName.Substring(endTrimIndex));
			}

			physicalPath = System.IO.Path.Combine(basePath, fileName);
			if (System.IO.File.Exists(physicalPath))
			{
				var fileInfo = new System.IO.FileInfo(physicalPath);

				var buff = System.IO.File.ReadAllBytes(physicalPath);

				webResource = new WebResource(buff, CfxRuntime.GetMimeType(System.IO.Path.GetExtension(fileName).TrimStart('.')));

				callback.Continue();
				e.SetReturnValue(true);
			}
			else
			{

				callback.Continue();
				e.SetReturnValue(false);
				Console.WriteLine($"[找不到资源]:\t{requestUrl}");

			}

		}

		private void OnGetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
		{
			if (webResource == null)
			{
				e.Response.Status = 404;
			}
			else
			{

				var length = webResource.data.Length;
				e.ResponseLength = webResource.data.Length;
				e.Response.MimeType = webResource.mimeType;
				e.Response.Status = 200;

				var headers = e.Response.GetHeaderMap();

				if (isPartContent)
				{
					headers.Add(new string[2] { "Accept-Ranges", "bytes" });
					var startPos = 0;
					var endPos = length - 1;



					if (buffStartPostition.HasValue && buffEndPostition.HasValue)
					{
						startPos = buffStartPostition.Value;
						endPos = buffEndPostition.Value;
					}
					else if (!buffEndPostition.HasValue && buffStartPostition.HasValue)
					{
						startPos = buffStartPostition.Value;
					}



					headers.Add(new string[2] { "Content-Range", $"bytes {startPos}-{endPos}/{webResource.data.Length}" });
					headers.Add(new string[2] { "Content-Length", $"{endPos - startPos + 1}" });

					e.ResponseLength = (endPos - startPos + 1);

					e.Response.Status = 206;

				}


				e.Response.SetHeaderMap(headers);

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
				Console.WriteLine($"[加载文件资源]:\t{requestUrl}");
				Console.WriteLine($" -> \t{physicalPath}");
			}

		}

	}
}
