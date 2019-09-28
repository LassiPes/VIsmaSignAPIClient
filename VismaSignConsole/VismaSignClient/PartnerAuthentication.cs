using System;
using System.Net.Http.Headers;

namespace VismaSignClientLib
{
    public class PartnerAuthentication : IAuthentication
    {
        private IHttpClient _client;
        private string _clientId;
        private string _clientSecret;
        private string _scope;
        private IEnvironment _environment;
        private IResponseParser _responseParser;

        public PartnerAuthentication(IHttpClient client, IEnvironment environment, IResponseParser responseParser, string clientId, string clientSecret, string scope)
        {
            _client = client;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = scope;
            _environment = environment;
            _responseParser = responseParser;
        }
        public IRequest AddAuthenticationHeaders(IRequest request)
        {
            IResponse response = GetTokenResponse();
            if (response.IsSuccessStatusCode())
            {
                Token token = _responseParser.FromJsonString<Token>(response.ResponseContent);
                request.HttpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue($"{token.token_type} {token.access_token}");
                return request;
            }
            else
            {
                throw new Exception("Getting token failed");
            }
        }

        public IResponse GetTokenResponse()
        {
            TokenRequest tokenRequest = new TokenRequest()
            {
                grant_type = "client_credential",
                client_id =_clientId,
                client_secret=_clientSecret,
                scope=_scope

            };
            IRequest request = new ClientHttpPostRequest<TokenRequest>(_environment, _responseParser, "/api/v1/auth/token", tokenRequest);
            IResponse response = _client.SendRequest(request);
            return response;
        }
    }
}
