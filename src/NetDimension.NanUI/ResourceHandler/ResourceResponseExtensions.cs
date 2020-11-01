using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetDimension.NanUI.ResourceHandler
{
    public static class ResourceResponseExtensions
    {
        public static void JsonContent(this ResourceResponse response, object data, JsonSerializerOptions jsonSerializerOptions = null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(data, data.GetType(), jsonSerializerOptions);

            response.Content(bytes, "application/json");
        }


        public static void JsonContent<T>(this ResourceResponse response, T data, JsonSerializerOptions jsonSerializerOptions = null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(data, jsonSerializerOptions);

            response.Content(bytes, "application/json");
        }


        public static void TextContent(this ResourceResponse response, string text)
        {
            TextContent(response, text, Encoding.UTF8);
        }


        public static void TextContent(this ResourceResponse response, string text, Encoding encoding)
        {
            Content(response, text, "text/plain", encoding);
        }


        public static void Content(this ResourceResponse response, string content)
        {
            response.Content(Encoding.UTF8.GetBytes(content), "text/plain");
        }

        public static void Content(this ResourceResponse response, string content, string contentType)
        {
            response.Content(Encoding.UTF8.GetBytes(content), contentType);
        }

        public static void Content(this ResourceResponse response, string content, string contentType, Encoding encoding)
        {
            response.Content(encoding.GetBytes(content), contentType);
        }



    }
}
