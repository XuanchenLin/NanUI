using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace NetDimension.NanUI.ResourceHandler
{

    public enum Method
    {
        /// <summary>
        /// The none.
        /// </summary>
        None,

        /// <summary>
        /// The get.
        /// </summary>
        GET,

        /// <summary>
        /// The post.
        /// </summary>
        POST,

        /// <summary>
        /// The put.
        /// </summary>
        PUT,

        /// <summary>
        /// The delete.
        /// </summary>
        DELETE,

        /// <summary>
        /// The head.
        /// </summary>
        HEAD,

        /// <summary>
        /// The options.
        /// </summary>
        OPTIONS,

        /// <summary>
        /// The patch.
        /// </summary>
        PATCH,

        /// <summary>
        /// The merge.
        /// </summary>
        MERGE
    }

    public class FormiumRequest
    {
        public Uri Uri { get; }
        public string RequestUrl
        {
            get
            {
                var original = Uri.OriginalString;
                if (original.IndexOf("?") >= 0)
                {
                    return original.Substring(0, original.IndexOf("?"));
                }

                return original;
            }
        }

        

        public RequestHeader Headers { get; }
        public string[] Files { get; }
        public byte[] Body { get; }
        private readonly string method;

        public QueryString QueryString { get; }

        public Method Method { 
            get 
            { 
                if(Enum.TryParse(method, out Method value))
                {
                    return value;
                }

                return Method.None;
            }
        }

        public string ContentType => Headers["content-type"]?.Value ?? string.Empty;

        

        internal FormiumRequest(Uri uri, string method, IDictionary<string, string[]> headers, byte[] postData, string[] uploadFiles)
        {
            Uri = uri;
            this.method = method;
            Files = uploadFiles;
            Body = postData;

            Headers = new RequestHeader(headers);
            QueryString = ProcessQueryString(uri.Query);
        }

        

        private QueryString ProcessQueryString(string query)
        {
            var queryParams = new Dictionary<string, List<string>>();

            query = query.Trim('?');

            foreach(var seg in query.Split(new char[] { '&' },  StringSplitOptions.RemoveEmptyEntries))
            {
                var kv = seg.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var key = kv[0];
                var value = kv[1];

                if (!queryParams.ContainsKey(key))
                {
                    queryParams[key] = new List<string>();
                }

                var values = queryParams[key];

                if (!values.Contains(value))
                {
                    values.Add(Uri.EscapeDataString(value));
                }
            }

            return new QueryString(queryParams.ToDictionary(k => k.Key, v => v.Value.ToArray()));

            

        }

    }


}