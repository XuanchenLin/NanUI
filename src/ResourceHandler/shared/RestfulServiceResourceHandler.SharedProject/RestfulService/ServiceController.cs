using NetDimension.NanUI.ResourceHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI.RestfulService
{
    public class ServiceController
    {

        protected FormiumResponse Json(object data)
        {
            var response = new FormiumResponse();
            response.MimeType = "application/json";
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            return response;
        }

        protected FormiumResponse Content(string content)
        {
            return Content(content, "text/plain", Encoding.UTF8);
        }

        protected FormiumResponse Content(string content, string contentType)
        {
            return Content(content, contentType, Encoding.UTF8);
        }

        protected FormiumResponse Content(string content, string contentType, Encoding encoding)
        {
            return Content(encoding.GetBytes(content), contentType);
        }

        protected FormiumResponse Content(byte[] content, string contentType)
        {
            var response = new FormiumResponse();
            response.MimeType = contentType;
            response.ContentStream = new MemoryStream(content);
            return response;
        }

        protected FormiumResponse StatusCode(System.Net.HttpStatusCode code)
        {
            return StatusCode((int)code);
        }

        protected FormiumResponse StatusCode(int code)
        {
            var response = new FormiumResponse();
            response.Status = code;
            return response;
        }

    }
}
