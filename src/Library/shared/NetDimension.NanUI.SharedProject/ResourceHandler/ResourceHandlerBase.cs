using Chromium;
using ColoredConsole;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetDimension.NanUI.ResourceHandler
{
    public abstract class ResourceHandlerBase : CfxResourceHandler
    {
        private GCHandle gcHandle;

        private int readStreamOffset;
        private int? buffStartPostition = null;
        private int? buffEndPostition = null;
        private bool isPartContent = false;
        private CancellationTokenSource cancellationTokenSource;

        //private WebResourceStream webResource;

        private FormiumResponse formiumResponse;

        private List<ColorToken> Info = new List<ColorToken>();

        public ResourceHandlerBase()
        {
            gcHandle = GCHandle.Alloc(this);

            this.Open += OnOpen;
            this.GetResponseHeaders += OnGetResponseHeaders;
            this.Read += OnRead;
            this.Skip += OnSkip;



            Info.Add("[ResourceHandler:".Green());
            Info.Add($"{this.GetType().Name}".Cyan());
            Info.Add("]".Green());
        }

        private void OnSkip(object sender, Chromium.Event.CfxSkipEventArgs e)
        {
            e.BytesSkipped = e.BytesToSkip;
            e.SetReturnValue(true);
        }

        private void OnOpen(object sender, Chromium.Event.CfxOpenEventArgs e)
        {
            var request = e.Request;
            var callback = e.Callback;
            var uri = new Uri(request.Url);


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

            readStreamOffset = 0;

            if (buffStartPostition.HasValue)
            {
                readStreamOffset = buffStartPostition.Value;
            }


            byte[] postData = null;
            var uploadFiles = new List<string>();


            if (e.Request.PostData != null && e.Request.PostData.Elements != null)
            {
                var items = e.Request.PostData.Elements;
                var bytes = new List<byte>();
                foreach (var item in items)
                {

                    var size = (int)item.BytesCount;

                    var buffer = new byte[size];

                    var ptr = Marshal.AllocHGlobal(buffer.Length);


                    item.GetBytes(item.BytesCount, ptr);

                    Marshal.Copy(ptr, buffer, 0, size);



                    switch (item.Type)
                    {
                        case CfxPostdataElementType.Empty:
                            break;
                        case CfxPostdataElementType.Bytes:
                            bytes.AddRange(buffer);
                            break;
                        case CfxPostdataElementType.File:
                            uploadFiles.Add(item.File);
                            break;
                    }

                    Marshal.FreeHGlobal(ptr);
                }
                postData = bytes.ToArray();
                bytes = null;
            }

            var method = request.Method;

            var requestHeaders = new Dictionary<string, List<string>>();

            foreach (var header in headers)
            {
                if (!requestHeaders.ContainsKey(header.Key) || requestHeaders[header.Key] == null)
                {
                    requestHeaders[header.Key] = new List<string>();
                }
                var stringValues = requestHeaders[header.Key];
                stringValues.Add(header.Value);
            }

            var contentType = request.GetHeaderByName("Content-Type");


            var formiumRequest = new FormiumRequest(uri, method, requestHeaders.ToDictionary(k => k.Key.ToLower(), v => v.Value.ToArray()), postData, uploadFiles.ToArray());

            e.SetReturnValue(true);
            e.HandleRequest = false;

            cancellationTokenSource = new CancellationTokenSource();


            Task.Factory.StartNew(() =>
            {
                try
                {
                    Info.Add($" [{request.Method}] ".Magenta());
                    Info.Add($"{formiumRequest.RequestUrl}".Gray());

                    formiumResponse = GetResponse(formiumRequest);

                    if (formiumResponse.Status != (int)System.Net.HttpStatusCode.OK)
                    {
                        Info.Add($" [ERR]:{formiumResponse.Status}".Red());
                    }
                    else
                    {
                        Info.Add($"...".Gray());
                    }


                }
                catch
                {

                }

            }, cancellationTokenSource.Token).ContinueWith(t => callback.Continue());

            return;
        }

        //abstract protected WebResourceStream GetResourceStream(string relativePath/*, Uri requestUri, string method, string postData*/);

        abstract protected FormiumResponse GetResponse(FormiumRequest request);

        private void OnGetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
        {


            var statusCode = formiumResponse?.Status ?? (int)System.Net.HttpStatusCode.BadRequest;

            e.Response.Status = statusCode;

            if (statusCode == 200)
            {
                var length = formiumResponse.Length;
                e.ResponseLength = (int)length;
                e.Response.MimeType = formiumResponse.MimeType;
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



                    headers.Add(new string[2] { "Content-Range", $"bytes {startPos}-{endPos}/{formiumResponse.Length}" });
                    headers.Add(new string[2] { "Content-Length", $"{endPos - startPos + 1}" });

                    e.ResponseLength = (endPos - startPos + 1);

                    e.Response.Status = 206;

                    var extraInfo = new List<ColorToken>(Info.ToArray());

                    extraInfo.Add("[Content-Range:".Cyan());
                    extraInfo.Add($"{startPos}-{endPos}/{formiumResponse.Length-1}".Gray());
                    extraInfo.Add("]".Cyan());

                    Bootstrap.Log(extraInfo.ToArray());

                }

                foreach (var header in formiumResponse.Headers)
                {
                    foreach(var value in header.Value)
                    {
                        headers.Add(new string[2] { header.Key, value });
                    }
                }


                e.Response.SetHeaderMap(headers);
            }
            else
            {
                Bootstrap.Log(Info.ToArray());
            }
        }

        private void OnRead(object sender, Chromium.Event.CfxResourceHandlerReadEventArgs e)
        {
            var total = formiumResponse?.Length ?? 0;

            var bytesToCopy = (int)(total - readStreamOffset);

            if (total == 0 || bytesToCopy == 0)
            {
                e.SetReturnValue(false);
                return;
            }


            if (bytesToCopy > e.BytesToRead)
                bytesToCopy = e.BytesToRead;

            byte[] buff = new byte[bytesToCopy];



            formiumResponse.ContentStream.Position = readStreamOffset;
            formiumResponse.ContentStream.Read(buff, 0, bytesToCopy);

            Marshal.Copy(buff, 0, e.DataOut, bytesToCopy);

            readStreamOffset += bytesToCopy;

            e.BytesRead = bytesToCopy;

            e.SetReturnValue(true);


            if (readStreamOffset == formiumResponse.Length)
            {
                if (!formiumResponse.ShouldCached)
                {
                    formiumResponse.Dispose();
                    formiumResponse = null;
                }
                gcHandle.Free();

                Info.Add($" [OK]".Green());

                Bootstrap.Log(Info.ToArray());

            }
        }
    }
}
