using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    public sealed class MessageArrayValue : MessageValue, IList<MessageValue>
    {

        List<MessageValue> _array;
        internal MessageArrayValue()
        {
            _array = new List<MessageValue>();
            ValueType = MessageValueType.Array;
        }

        public static MessageValue Create()
        {
            return new MessageArrayValue();
        }


        public MessageValue this[int index] { get => _array[index]; set => _array[index] = value; }

        public new int Count => _array.Count;

        public bool IsReadOnly => false;

        public void Add(MessageValue item)
        {
            _array.Add(item);
        }

        public void Clear()
        {
            _array.Clear();
        }

        public bool Contains(MessageValue item)
        {
            return _array.Contains(item);
        }

        public void CopyTo(MessageValue[] array, int arrayIndex)
        {
            _array.CopyTo(array, arrayIndex);
        }

        public IEnumerator<MessageValue> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        public int IndexOf(MessageValue item)
        {
            return _array.IndexOf(item);
        }

        public void Insert(int index, MessageValue item)
        {
            _array.Insert(index, item);
        }

        public bool Remove(MessageValue item)
        {
            return _array.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _array.RemoveAt(index);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}
