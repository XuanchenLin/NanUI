using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public abstract class DataService
    {
        protected ResourceResponse Json(object data, System.Text.Json.JsonSerializerOptions jsonSerializerOptions = null)
        {
            var response = new ResourceResponse();

            response.JsonContent(data, jsonSerializerOptions);

            return response;
        }

        protected ResourceResponse Text(string text)
        {
            var response = new ResourceResponse();

            response.Content(text);

            return response;
        }

        protected ResourceResponse Content(string content, string contentType)
        {
            var response = new ResourceResponse();

            response.Content(Encoding.UTF8.GetBytes(content), contentType);

            return response;

        }

        protected ResourceResponse Content(string content, string contentType, Encoding encoding)
        {
            var response = new ResourceResponse();

            response.Content(encoding.GetBytes(content), contentType);

            return response;

        }

        protected ResourceResponse Content(byte[] buffer, string contentType = null )
        {
            var response = new ResourceResponse();

            response.Content(buffer, contentType);

            return response;
        }

        protected ResourceResponse StatusCode(System.Net.HttpStatusCode status)
        {
            var response = new ResourceResponse();
            response.HttpStatus = status;
            return response;

        }

        protected ResourceResponse StatusCode(int code)
        {
            return StatusCode((System.Net.HttpStatusCode)code);
        }
    }
}
