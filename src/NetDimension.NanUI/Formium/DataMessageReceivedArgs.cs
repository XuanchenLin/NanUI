namespace NetDimension.NanUI;



public class DataMessageReceivedArgs : EventArgs
{
    public string MessageName { get; }

    private string _json;

    public string Json { get; }

    public bool HasData { get; }


    internal DataMessageReceivedArgs(string message, string json)
    {
        MessageName = message;
        _json = json;

        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                Json = json;

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
            return JsonSerializer.Deserialize<T>(_json);
        }

        return default(T);
    }

}
