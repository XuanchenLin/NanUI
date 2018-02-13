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
		private string basePath = null;

		private int? buffStartPostition = null;
		private int? buffEndPostition = null;
		private bool isPartContent = false;

		internal AssemblyResourceHandler(Assembly resourceAssembly, BrowserCore browser, string domain, string basePath = null)
		{
			gcHandle = GCHandle.Alloc(this);
			this.basePath = basePath;
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
					if (!string.IsNullOrEmpty(group["start"].Value) && int.TryParse(group["start"].Value, out int startPos)){
						buffStartPostition = startPos;
					}

					if (!string.IsNullOrEmpty(group["end"].Value) && int.TryParse(group["end"].Value, out int endPos)){
						buffEndPostition = endPos;
					}
				}

				isPartContent = true;

			}

			readResponseStreamOffset = 0;

			if (buffStartPostition.HasValue)
			{
				readResponseStreamOffset = buffStartPostition.Value;
			}



			if (browser != null && browser.WebResources.ContainsKey(requestUrl))
			{
				webResource = browser.WebResources[requestUrl];
				callback.Continue();
				e.SetReturnValue(true);
				return;
			}



			var fileName = string.IsNullOrEmpty(domain) ? string.Format("{0}{1}", uri.Authority, uri.AbsolutePath) : uri.AbsolutePath;

			if (fileName.StartsWith("/") && fileName.Length > 1)
			{
				fileName = fileName.Substring(1);
			}

			if (!string.IsNullOrEmpty(basePath))
			{
				fileName = $"{basePath}/{fileName}";
			}

			var mainAssembly = resourceAssembly;
			var endTrimIndex = fileName.LastIndexOf('/');

			if (endTrimIndex > -1)
			{
				var tmp = fileName.Substring(0, endTrimIndex);
				tmp = tmp.Replace("-", "_");

				fileName = string.Format("{0}{1}", tmp, fileName.Substring(endTrimIndex));
			}

			var resourcePath = string.Format("{0}.{1}", mainAssembly.GetName().Name, fileName.Replace('/', '.'));



			Assembly satelliteAssembly = null;

			try
			{
				satelliteAssembly = mainAssembly.GetSatelliteAssembly(System.Threading.Thread.CurrentThread.CurrentCulture);
			}
			catch
			{

			}

			
			var resourceNames = mainAssembly.GetManifestResourceNames().Select(x => new { TargetAssembly = mainAssembly, Name = x, IsSatellite = false });

			if (satelliteAssembly != null)
			{
				string HandleCultureName(string name)
				{
					var cultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
					var fileInfo = new System.IO.FileInfo(name);

					return $"{System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name)}.{cultureName}{fileInfo.Extension}";
				}

				resourceNames = resourceNames.Union(satelliteAssembly.GetManifestResourceNames().Select(x => new { TargetAssembly = satelliteAssembly, Name = HandleCultureName(x), IsSatellite = true }));
			}

			var resource = resourceNames.SingleOrDefault(p => p.Name.Equals(resourcePath, StringComparison.CurrentCultureIgnoreCase));
			var manifestResourceName = resourcePath;
			if (resource != null && resource.IsSatellite)
			{
				var fileInfo = new System.IO.FileInfo(manifestResourceName);
				manifestResourceName = $"{System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name))}{fileInfo.Extension}";
			}

			if (resource != null && resource.TargetAssembly.GetManifestResourceStream(manifestResourceName) != null)
			{


				using (var reader = new System.IO.BinaryReader(resource.TargetAssembly.GetManifestResourceStream(manifestResourceName)))
				{
					var buff = reader.ReadBytes((int)reader.BaseStream.Length);
					
					webResource = new WebResource(buff, CfxRuntime.GetMimeType(System.IO.Path.GetExtension(fileName).TrimStart('.')));

					if (browser != null)
					{
						browser.SetWebResource(requestUrl, webResource);
					}


					reader.Close();

				}

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
