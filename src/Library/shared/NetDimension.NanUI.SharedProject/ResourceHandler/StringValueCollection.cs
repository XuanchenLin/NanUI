using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.ResourceHandler
{
    public class StringValueCollection : IEnumerable<string>
    {

        readonly List<string> RawStrings;

        public StringValueCollection(string[] raw)
        {
            RawStrings = new List<string>(raw);
        }

        public int Count => RawStrings.Count;

        public string Value => RawStrings.FirstOrDefault();

        public IEnumerable<string> Values => RawStrings;

        public string[] ToArray()
        {
            return RawStrings.ToArray();
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < RawStrings.Count; i++)
            {
                yield return RawStrings[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }


}
