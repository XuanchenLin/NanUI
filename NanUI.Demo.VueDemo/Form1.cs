using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

using Chromium;
using Chromium.Event;
using Chromium.Remote;
using NetDimension.NanUI;

using Newtonsoft.Json;

namespace NanUI.Demo.VueDemo
{
    public partial class Form1 : HtmlUIForm
    {
        public Form1()
            : base("local:///vueDemo/index.html", false) //设定启示页面，scheme是local表示我们使用本地文件资源(不是嵌入到程序集的资源)
        {
            InitializeComponent();

            this.LoadHandler.OnLoadStart += LoadHandler_OnLoadStart;
            this.LoadHandler.OnLoadEnd += LoadHandler_OnLoadEnd;
            this.DownloadHandler.OnBeforeDownload += DownloadHandler_OnBeforeDownload;
            this.RequestHandler.OnBeforeBrowse += RequestHandler_OnBeforeBrowse;
            this.RequestHandler.GetResourceHandler += RequestHandler_GetResourceHandler;
        }
        private void LoadHandler_OnLoadEnd(object sender, Chromium.Event.CfxOnLoadEndEventArgs e)
        {
            //MessageBox.Show("end loading" + e.Frame.Url);
            //MessageBox.Show("is main:" + e.Frame.IsMain);
            //e.Frame.SelectAll();
        }

        private void LoadHandler_OnLoadStart(object sender, Chromium.Event.CfxOnLoadStartEventArgs e)
        {
            //MessageBox.Show("start loading"+e.Frame.Url);
        }

        private void DownloadHandler_OnBeforeDownload(object sender, Chromium.Event.CfxOnBeforeDownloadEventArgs e)
        {
            //e.Callback.Continue("d:\\" + e.SuggestedName, false);
        }

        private void RequestHandler_OnBeforeBrowse(object sender, Chromium.Event.CfxOnBeforeBrowseEventArgs e)
        {
            //if (e.Request.Url == "")
            //{
            //    e.SetReturnValue(true);
            //}
        }

        /// <summary>
        /// 分析 url 字符串中的参数信息
        /// </summary>
        /// <param name="url">输入的 URL</param>
        /// <param name="baseUrl">输出 URL 的基础部分</param>
        /// <param name="nvc">输出分析后得到的 (参数名,参数值) 的集合</param>
        public static void ParseUrl(string url, out string baseUrl, out NameValueCollection nvc)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            nvc = new NameValueCollection();
            baseUrl = "";
            if (url == "")
                return;
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex == -1)
            {
                //baseUrl = url;
                //return;
            }
            else if (questionMarkIndex == url.Length - 1)
            {
                return;
            }
            else
            {
                baseUrl = url.Substring(0, questionMarkIndex);
            }
            string ps = url.Substring(questionMarkIndex + 1);
            // 使用正则表达式分析key-value对
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(ps);
            foreach (Match m in mc)
            {
                string key = HttpUtility.UrlDecode(m.Result("$2").ToLower());
                string value = HttpUtility.UrlDecode(m.Result("$3"));
                nvc.Add(key, value);
            }
        }

        private NameValueCollection GetPostData(CfxPostData PostData)
        {
            List<string> list = new List<string>();

            foreach (CfxPostDataElement data in PostData.Elements)
            {
                IntPtr val = Marshal.AllocHGlobal(data.BytesCount);
                data.GetBytes(data.BytesCount, val);
                Byte[] bytes = new Byte[data.BytesCount];
                Marshal.Copy(val, bytes, 0, bytes.Length);
                Marshal.FreeHGlobal(val);

                list.Add(Encoding.UTF8.GetString(bytes));
            }
            string url = String.Join("&", list.ToArray());
            string baseUrl;
            NameValueCollection nvc;
            ParseUrl(url, out baseUrl, out nvc);
            return nvc;
        }
        public static Dictionary<string, string> ConvertNameValueCollectionToDictionary(NameValueCollection nvc)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string key in nvc.AllKeys)
            {
                dict[key] = nvc[key];
            }
            return dict;
        }
        private void RequestHandler_GetResourceHandler(object sender, Chromium.Event.CfxGetResourceHandlerEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Method: " + e.Request.Method);
            sb.AppendLine("Url: " + e.Request.Url);
            //sb.AppendLine("ReferrerUrl: " + e.Request.ReferrerUrl);
            if (e.Request.PostData != null)
            {
                NameValueCollection nvc = GetPostData(e.Request.PostData);
                Dictionary<string, string> dict = ConvertNameValueCollectionToDictionary(nvc);
                string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
                sb.AppendLine(json);
            }
            MessageBox.Show(sb.ToString());

            //if (e.Request.Url == "http://m.baidu.com/")
            //{
            //    CfxResourceHandler handler = new CfxResourceHandler();
            //    handler.ProcessRequest += handler_ProcessRequest;
            //    handler.GetResponseHeaders += handler_GetResponseHeaders;
            //    handler.ReadResponse += handler_ReadResponse;

            //    e.SetReturnValue(handler);
            //}
            //else
            //{
            //    e.SetReturnValue(null);
            //}
        }

        //响应未知长度已知的情况
        private void handler_ProcessRequest(object sender, Chromium.Event.CfxProcessRequestEventArgs e)
        {
            e.Callback.Continue();
            e.SetReturnValue(true);
        }

        private void handler_GetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
        {
            e.ResponseLength = -1;
            e.Response.MimeType = "text/html";
            e.Response.Status = 200;
        }


        int count = 0;
        private void handler_ReadResponse(object sender, Chromium.Event.CfxReadResponseEventArgs e)
        {
            if (count == 0)
            {
                byte[] data = Encoding.UTF8.GetBytes("<html><body><h1>Hello CEF</h1></body></html>");
                e.BytesRead = data.Length;
                Marshal.Copy(data, 0, e.DataOut, data.Length);
                e.SetReturnValue(true);
                count++;
            }
            else
            {
                e.SetReturnValue(false);
            }
        }

        //响应长度已知的情况
        //void handler_GetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
        //{
        //    e.ResponseLength = Encoding.UTF8.GetBytes("<html><body><h1>Hello CEF</h1></body></html>").Length;
        //    e.Response.MimeType = "text/html";
        //    e.Response.Status = 200;
        //}

        //void handler_ReadResponse(object sender, Chromium.Event.CfxReadResponseEventArgs e)
        //{
        //    byte[] data = Encoding.UTF8.GetBytes("<html><body><h1>Hello CEF</h1></body></html>");
        //    e.BytesRead = data.Length;
        //    Marshal.Copy(data, 0, e.DataOut, data.Length);
        //    e.SetReturnValue(true);
        //}
    }
}
