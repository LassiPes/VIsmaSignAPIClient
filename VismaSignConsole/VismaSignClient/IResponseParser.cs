namespace VismaSignClientLib
{
    public interface IResponseParser
    {
        T FromJsonString<T>(string json);
        string ToJsonString<T>(T instance);
    }
}
