using System.Net.Http;

namespace VismaSignClientLib
{
    public class ClientHttpResponse : IResponse
    {
        private HttpResponseMessage _response;
        public ClientHttpResponse(HttpResponseMessage response)
        {
            _response = response;
        }
        public bool IsSuccessStatusCode()
        {
            return _response.IsSuccessStatusCode;
        }

        public string Location
        {
            get
            {
                return _response.Headers.Location.ToString();
            }
        }

        public string ResponseContent
        {
            get
            {
                return _response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
