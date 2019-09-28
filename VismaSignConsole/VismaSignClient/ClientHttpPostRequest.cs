using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace VismaSignClientLib
{
    public class ClientHttpPostRequest<T> : ClientHttpRequestBase, IRequest
    {
        public ClientHttpPostRequest(IEnvironment environment, IResponseParser responseParser, string url, T instance) : base(HttpMethod.Post, environment, url)
        {
            if (instance is byte[])
            {
                base._requestMessage.Content = new ByteArrayContent(Converter.ObjectToByteArray(instance));
                base._requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            }
            else
            {
                string json = responseParser.ToJsonString(instance);
                base._requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
        }



    }
}
