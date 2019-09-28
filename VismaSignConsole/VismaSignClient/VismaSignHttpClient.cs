using System.Net.Http;

namespace VismaSignClientLib
{
    public class VismaSignHttpClient: IHttpClient
    {
        private IAuthentication _authentication;
        public VismaSignHttpClient(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public IResponse SendRequest(IRequest request)
        {
            request = _authentication.AddAuthenticationHeaders(request);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request.HttpRequestMessage).GetAwaiter().GetResult();
                return new ClientHttpResponse(response);
            }
        }
    }
}
