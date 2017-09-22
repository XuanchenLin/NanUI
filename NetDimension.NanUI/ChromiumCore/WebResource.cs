// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Chromium.Event;

namespace Chromium.WebBrowser {

	/// <summary>
	/// Custom web resource for registration with a
	/// ChromiumWebBrowser control.
	/// </summary>
	public class WebResource {

		public readonly byte[] data;
		public readonly string mimeType;

		/// <summary>
		/// Creates a WebResource for registration with a
		/// ChromiumWebBrowser control.
		/// </summary>
		public WebResource(byte[] data, string mimeType) {
			this.data = data;
			this.mimeType = mimeType;
		}

		/// <summary>
		/// Creates a WebResource from the given image
		/// for registration with a ChromiumWebBrowser control.
		/// The mime type will be image/png 
		/// </summary>
		/// <param name="image"></param>
		public WebResource(Image image) {
		   mimeType = "image/png";
			var pngData = new System.IO.MemoryStream();
			image.Save(pngData, ImageFormat.Png);
			data = pngData.ToArray();
		}

		/// <summary>
		/// Creates a WebResource from the given image
		/// for registration with a ChromiumWebBrowser control.
		/// The mime type will be set according to the image format.
		/// </summary>
		public WebResource(Image image, ImageFormat format) {
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
			foreach(var c in codecs) {
				if(c.FormatID == format.Guid) {
					mimeType = c.MimeType;
					var imgData = new System.IO.MemoryStream();
					image.Save(imgData, format);
					data = imgData.ToArray();
					return;
				}
			}
			throw new CefException("No mime type for the given image format.");
		}

		/// <summary>
		/// Creates a WebResource from the given text
		/// for registration with a ChromiumWebBrowser control.
		/// The mime type will be text/html
		/// </summary>
		/// <param name="html"></param>
		public WebResource(string html) {
			mimeType = "text/html";
			data = System.Text.Encoding.UTF8.GetBytes(html);
		}

		internal CfxResourceHandler GetResourceHandler() {
			return new WebResourceHandler(this);
		}

	}

	internal class WebResourceHandler : CfxResourceHandler {

		private readonly WebResource webResource;
		private int bytesDone;
		private GCHandle gcHandle;

		internal WebResourceHandler(WebResource webResource) {

			gcHandle = GCHandle.Alloc(this);

			this.webResource = webResource;
			GetResponseHeaders += new CfxGetResponseHeadersEventHandler(ResourceHandler_GetResponseHeaders);
			ProcessRequest += new CfxProcessRequestEventHandler(ResourceHandler_ProcessRequest);
			ReadResponse += new CfxReadResponseEventHandler(ResourceHandler_ReadResponse);
		}

		void ResourceHandler_ProcessRequest(object sender, CfxProcessRequestEventArgs e) {
			bytesDone = 0;
			e.Callback.Continue();
			e.SetReturnValue(true);
		}

		void ResourceHandler_GetResponseHeaders(object sender, CfxGetResponseHeadersEventArgs e) {
			e.ResponseLength = webResource.data.Length;
			e.Response.MimeType = webResource.mimeType;
			e.Response.Status = 200;
			e.Response.StatusText = "OK";
		}

		void ResourceHandler_ReadResponse(object sender, CfxReadResponseEventArgs e) {
			int bytesToCopy = webResource.data.Length - bytesDone;
			if(bytesToCopy > e.BytesToRead)
				bytesToCopy = e.BytesToRead;
			Marshal.Copy(webResource.data, bytesDone, e.DataOut, bytesToCopy);
			e.BytesRead = bytesToCopy;
			bytesDone += bytesToCopy;
			e.SetReturnValue(true);

			if (bytesDone == webResource.data.Length)
			{
				gcHandle.Free();
			}
		}
	}

}
