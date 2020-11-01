using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    public sealed class MessageObjectValue : MessageValue, IDictionary<string, MessageValue>
    {
        Dictionary<string, MessageValue> _object;
        internal MessageObjectValue()
        {
            _object = new Dictionary<string, MessageValue>();
            ValueType =  MessageValueType.Object;

            
        }

        public static MessageObjectValue Create()
        {
            return new MessageObjectValue();
        }

        public MessageValue this[string key] { get => _object[key]; set => _object[key] = value; }

        public ICollection<string> Keys => _object.Keys;

        public ICollection<MessageValue> Values => _object.Values;

        public int Count => _object.Count;

        public bool IsReadOnly => false;

        public void Add(string key, MessageValue value)
        {
            _object.Add(key, value);
        }

        public void Add(KeyValuePair<string, MessageValue> item)
        {
            _object.Add(item.Key,item.Value);

        }

        public void Clear()
        {
            _object.Clear();
        }

        public bool Contains(KeyValuePair<string, MessageValue> item)
        {
            return _object.ContainsKey(item.Key) && _object.ContainsValue(item.Value);
        }

        public bool ContainsKey(string key)
        {
            return _object.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, MessageValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, MessageValue>> GetEnumerator()
        {
            return _object.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return _object.Remove(key);
        }

        public bool Remove(KeyValuePair<string, MessageValue> item)
        {
            return _object.Remove(item.Key);
        }

        public bool TryGetValue(string key, out MessageValue value)
        {
            return _object.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _object.GetEnumerator();
        }
    }
}
