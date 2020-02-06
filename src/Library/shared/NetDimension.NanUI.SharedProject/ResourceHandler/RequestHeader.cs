using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.ResourceHandler
{
    public class RequestHeader : IEnumerable<KeyValuePair<string, StringValueCollection>>
    {
        private IDictionary<string, string[]> KeyValues;
        private RequestHeader() {

        }

        internal RequestHeader(IDictionary<string, string[]> value)
        {
            KeyValues = value;
        }
        public int Count => KeyValues.Count;

        public StringValueCollection this[string key]
        {
            get
            {
                if (KeyValues.ContainsKey(key))
                {
                    return new StringValueCollection(KeyValues[key]);
                }

                return null;
            }
        }

        public IEnumerator<KeyValuePair<string, StringValueCollection>> GetEnumerator()
        {
            for (int i = 0; i < KeyValues.Keys.Count; i++)
            {
                var key = KeyValues.Keys.ElementAt(i);
                var value = KeyValues[key];
                yield return new KeyValuePair<string, StringValueCollection>(key, new StringValueCollection(value));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
