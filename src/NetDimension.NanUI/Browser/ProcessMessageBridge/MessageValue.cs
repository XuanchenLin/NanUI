using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NetDimension.NanUI.JavaScript;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{

    public enum MessageValueType
    {
        Invalid = 0,
        Null,
        Bool,
        Int,
        Double,
        String,
        Function,
        DateTime,
        Object,
        Array,
    }

    public class MessageValue
    {
        private readonly object _value;

        public MessageValueType ValueType { get; internal set; }

        protected MessageValue()
        {

        }

        private MessageValue(object value, MessageValueType type)
        {
            ValueType = type;
            _value = value;
        }

        public int Count
        {
            get
            {
                if (ValueType != MessageValueType.Array)
                {
                    throw new InvalidOperationException();
                }

                var array = (MessageArrayValue)this;

                return array.Count;
            }

        }

        public string[] Keys
        {
            get
            {
                if (ValueType != MessageValueType.Object)
                {
                    throw new InvalidOperationException();
                }
                var obj = (MessageObjectValue)this;

                return obj.Keys.ToArray();
            }
        }

        public string GetString()
        {
            switch (ValueType)
            {
                case MessageValueType.Invalid:
                    return "undefined";
                case MessageValueType.Bool:
                case MessageValueType.Int:
                case MessageValueType.Double:
                case MessageValueType.DateTime:
                    return $"{_value}";
                case MessageValueType.String:
                    return (string)_value;
                case MessageValueType.Object:
                    return $"[object]";
                case MessageValueType.Array:
                    return $"[array]";
                case MessageValueType.Function:
                    return $"[function]";
                default:
                    return null;
            }
        }

        public int GetInt()
        {
            if(ValueType == MessageValueType.Double || ValueType == MessageValueType.Int)
            {
                return (int)_value;
            }

            if(ValueType == MessageValueType.Bool)
            {
                return ((bool)_value) ? 1 : 0;
            }

            return 0;
        }

        public double GetDouble()
        {
            if (ValueType == MessageValueType.Double || ValueType == MessageValueType.Int)
            {
                return (double)_value;
            }

            if (ValueType == MessageValueType.Bool)
            {
                return ((bool)_value) ? 1 : 0;
            }

            return 0;
        }

        public DateTime GetDateTime()
        {
            if (ValueType == MessageValueType.String)
            {
                

                if (DateTime.TryParse((string)_value, out var retval))
                {
                    return retval;
                }
            }

            if(ValueType == MessageValueType.DateTime)
            {
                return (DateTime)_value;
            }

            return default;
        }

        public bool GetBool()
        {
            if (ValueType == MessageValueType.Int || ValueType == MessageValueType.Double)
            {
                return (int)_value != 0;
            }

            if(ValueType == MessageValueType.Bool)
            {
                return (bool)_value;
            }
            

            return false;
        }
        public MessageObjectValue GetObject()
        {
            if (ValueType != MessageValueType.Object)
            {
                throw new InvalidOperationException();
            }

            return (MessageObjectValue)this;
        }

        public MessageArrayValue GetArray()
        {
            if (ValueType != MessageValueType.Array)
            {
                throw new InvalidOperationException();
            }

            return (MessageArrayValue)this;
        }

        public void SetValue(int index, MessageValue value)
        {
            if (ValueType != MessageValueType.Array)
            {
                throw new InvalidOperationException();
            }

            var array = (MessageArrayValue)this;
            if (index >= array.Count)
            {
                array.Add(value);
            }
            else
            {
                array[index] = value;
            }
        }

        public void SetValue(string key, MessageValue value)
        {
            if (ValueType != MessageValueType.Object)
            {
                throw new InvalidOperationException();
            }

            var obj = (MessageObjectValue)this;
            obj.Add(key, value);
        }

        public static MessageValue CreateArray()
        {
            return new MessageArrayValue();
        }

        public static MessageValue CreateObject()
        {
            return new MessageObjectValue();
        }

        public static MessageValue CreateBool(bool value)
        {


            return new MessageValue(value, MessageValueType.Bool);
        }

        public static MessageValue CreateString(string value)
        {


            return new MessageValue(value, MessageValueType.String);
        }

        public static MessageValue CreateDate(DateTime value)
        {


            return new MessageValue(value, MessageValueType.DateTime);
        }

        public static MessageValue CreateInt(int value)
        {


            return new MessageValue(value, MessageValueType.Int);
        }

        public static MessageValue CreateDouble(double value)
        {
            if (Math.Abs(value % 1) < double.Epsilon)
            {

                return new MessageValue((int)value, MessageValueType.Int);
            }


            return new MessageValue(value, MessageValueType.Double);
        }

        public static MessageValue CreateNull()
        {
            return new MessageValue(null, MessageValueType.Null);
        }



        public string ToJson(bool formatted = false)
        {
            var retval = string.Empty;


            using (var ms = new MemoryStream())
            using (var jw = new Utf8JsonWriter(ms, new JsonWriterOptions { Indented = formatted, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }))
            {

                WriteJsonValue(jw);

                jw.Flush();

                retval = Encoding.UTF8.GetString(ms.ToArray());
            }

            return retval;
        }

        public static MessageValue FromJson(string json)
        {
            var buff = Encoding.UTF8.GetBytes(json);
            Utf8JsonReader reader = new Utf8JsonReader(buff);

            MessageValue target = null;

            while (reader.Read())
            {
                ReadJsonValue(ref reader, ref target);
            }

            return target;
        }

        internal static void ReadJsonValue(ref Utf8JsonReader reader, ref MessageValue target)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    {
                        var value = reader.GetDouble();
                        if (Math.Abs(value % 1) < double.Epsilon)
                        {
                            target = CreateInt((int)value);
                        }
                        else
                        {
                            target = CreateDouble(value);

                        }
                    }
                    break;
                case JsonTokenType.Null:
                    {
                        target = CreateNull();
                    }
                    break;
                case JsonTokenType.String:
                    {
                        if (reader.TryGetDateTime(out var datettime))
                        {
                            target = CreateDate(datettime);
                        }
                        else
                        {
                            target = CreateString(reader.GetString());

                        }
                    }
                    break;
                case JsonTokenType.True:
                case JsonTokenType.False:
                    {
                        target = CreateBool(reader.GetBoolean());

                    }
                    break;
                case JsonTokenType.StartObject:
                    {
                        //reader.Read();

                        var obj = CreateObject();

                        do
                        {
                            reader.Read();

                            if (reader.TokenType == JsonTokenType.PropertyName)
                            {
                                var propName = reader.GetString();

                                MessageValue propValue = null;

                                reader.Read();

                                ReadJsonValue(ref reader, ref propValue);
                                obj.SetValue(propName, propValue);
                            }
                        } while (reader.TokenType != JsonTokenType.EndObject);

                        target = obj;

                        

                    }
                    break;
                case JsonTokenType.StartArray:
                    {
                        var array = CreateArray();

                        reader.Read();

                        do
                        {
                            MessageValue arrayValue = null;
                            ReadJsonValue(ref reader, ref arrayValue);

                            if (arrayValue != null)
                            {
                                array.SetValue(array.Count, arrayValue);
                            }
                        } while (reader.TokenType != JsonTokenType.EndArray);

                        target = array;

                    }
                    break;
            }

            reader.Read();
        }

        internal void WriteJsonValue(Utf8JsonWriter writer)
        {

            switch (ValueType)
            {
                case MessageValueType.Null:
                    writer.WriteNullValue();
                    break;
                case MessageValueType.Bool:
                    writer.WriteBooleanValue((bool)_value);
                    break;
                case MessageValueType.Int:
                    writer.WriteNumberValue((int)_value);
                    break;
                case MessageValueType.Double:
                    writer.WriteNumberValue((double)_value);
                    break;
                case MessageValueType.String:
                    writer.WriteStringValue((string)_value);
                    break;
                case MessageValueType.Function:
                    break;
                case MessageValueType.DateTime:
                    writer.WriteStringValue((DateTime)_value);
                    break;
                case MessageValueType.Object:
                    writer.WriteStartObject();
                    var dict = (MessageObjectValue)this;
                    foreach (var key in dict.Keys)
                    {
                        var source = dict[key];
                        writer.WritePropertyName(key);
                        source.WriteJsonValue(writer);
                    }
                    writer.WriteEndObject();
                    break;
                case MessageValueType.Array:
                    writer.WriteStartArray();
                    var array = (MessageArrayValue)this;
                    for (int i = 0; i < array.Count; i++)
                    {
                        var source = array[i];
                        source?.WriteJsonValue(writer);
                    }
                    writer.WriteEndArray();
                    break;
                default:
                    writer.WriteNullValue();
                    break;
            }
        }






    }
}
