using System.Net.Http;

namespace VismaSignClientLib
{
    public abstract class ClientHttpRequestBase 
    {
        protected HttpRequestMessage _requestMessage;

        public ClientHttpRequestBase(HttpMethod httpMethod, IEnvironment environment, string url)
        {
            _requestMessage = new HttpRequestMessage(httpMethod, environment.Root + url);
        }

        public HttpRequestMessage HttpRequestMessage
        {
            get
            {
                return _requestMessage;
            }
        }
}
}
