namespace NetDimension.NanUI;



public class DataMessageReceivedArgs : EventArgs
{
    public string MessageName { get; }

    private string _json;

    public Newtonsoft.Json.Linq.JToken Json { get; }

    public bool HasData { get; }


    internal DataMessageReceivedArgs(string message, string json)
    {
        MessageName = message;
        _json = json;

        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                Json = Newtonsoft.Json.Linq.JToken.Parse(json);

                HasData = true;
            }
            catch
            {

            }
        }
    }

    public T DeserializeData<T>()
    {
        if (HasData)
        {
            return JsonConvert.DeserializeObject<T>(_json);
        }

        return default(T);
    }

}