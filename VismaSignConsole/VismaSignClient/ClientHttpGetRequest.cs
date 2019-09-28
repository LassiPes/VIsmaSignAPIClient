using System.Net.Http;

namespace VismaSignClientLib
{
    public class ClientHttpGetRequest : ClientHttpRequestBase, IRequest
    {

        public ClientHttpGetRequest(IEnvironment environment, string url): base(HttpMethod.Get, environment, url)
        {
        }
    }
}
