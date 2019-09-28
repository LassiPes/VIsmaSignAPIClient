using Newtonsoft.Json;

namespace VismaSignClientLib
{
    public class ResponseParser: IResponseParser
    {
        public string ToJsonString<T>(T instance)
        {
            return JsonConvert.SerializeObject(instance);
        }

        public T FromJsonString<T>(string value)
        {
            T result = JsonConvert.DeserializeObject<T>(value);
            return result;
        }  

    }
}
