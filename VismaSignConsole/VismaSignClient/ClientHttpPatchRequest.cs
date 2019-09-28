using System.Net.Http;
using System.Text;

namespace VismaSignClientLib
{
    public class ClientHttpPatchRequest<T>: ClientHttpRequestBase, IRequest
    {
        public ClientHttpPatchRequest(IEnvironment environment, IResponseParser responseParser, string url, T instance): base(new HttpMethod("PATCH"), environment, url) 
        {
            string json = responseParser.ToJsonString(instance);
            base._requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
