// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.



using Chromium;
using Chromium.Event;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NetDimension.NanUI.Resource
{

	/// <summary>
	/// Custom web resource for registration with a
	/// ChromiumWebBrowser control.
	/// </summary>
	public class WebResource {

		internal readonly byte[] data;
		internal readonly string mimeType;

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
			throw new HtmlUIException("No mime type for the given image format.");
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

		public CfxResourceHandler GetResourceHandler() {
			return new WebResourceHandler(this);
		}
	}

	internal class WebResourceHandler : CfxResourceHandler {

		private readonly WebResource webResource;
		private int bytesDone;
		private System.Runtime.InteropServices.GCHandle gcHandle;


		internal WebResourceHandler(WebResource webResource) {
			gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(this);

			this.webResource = webResource;
			this.GetResponseHeaders += new CfxGetResponseHeadersEventHandler(ResourceHandler_GetResponseHeaders);
			this.ProcessRequest += new CfxProcessRequestEventHandler(ResourceHandler_ProcessRequest);
			this.ReadResponse += new CfxReadResponseEventHandler(ResourceHandler_ReadResponse);
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
