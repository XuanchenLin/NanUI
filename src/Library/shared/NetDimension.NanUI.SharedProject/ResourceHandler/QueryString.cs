using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.ResourceHandler
{
    public class QueryString: IEnumerable<KeyValuePair<string,StringValueCollection>>
    {
        readonly IDictionary<string, string[]> RawQueries;

        public QueryString(IDictionary<string, string[]> value)
        {
            RawQueries = value;
        }

        public int Count => RawQueries.Count;

        public StringValueCollection this[string key] { 
            get {
                if (!RawQueries.ContainsKey(key)) return null;

                return new StringValueCollection(RawQueries[key]);
            } 
        }

        public IEnumerator<KeyValuePair<string, StringValueCollection>> GetEnumerator()
        {
            for (int i = 0; i < RawQueries.Keys.Count; i++)
            {
                var key = RawQueries.Keys.ElementAt(i);
                var value = RawQueries[key];
                yield return new KeyValuePair<string, StringValueCollection>(key, new StringValueCollection(value));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }



}
