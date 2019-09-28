using System.Web;

namespace VismaSignClientLib
{
    public class VismaSignClient
    {
        private IHttpClient _client;
        private IEnvironment _environment;
        private IResponseParser _responseParser;
        public VismaSignClient(IAuthentication authentication, IEnvironment environment, IResponseParser responseParser)
        {
            _client = new VismaSignHttpClient(authentication);
            _environment = environment;
            _responseParser = responseParser;
        }
        
        public string DocumentCreate(Document document)
        {
            IRequest request = new ClientHttpPostRequest<Document>(_environment, _responseParser, "/api/v1/document/", document);
            IResponse response = _client.SendRequest(request);

            return response.Location;
        }

        public DocumentIdentifier DocumentAddFile(string documentUri, byte[] fileContent, string filename)
        {
            IRequest request = new ClientHttpPostRequest<byte[]>(_environment, _responseParser, documentUri + "/files?filename=" + HttpUtility.UrlEncode(filename), fileContent);
            IResponse response = _client.SendRequest(request);

            DocumentIdentifier document = _responseParser.FromJsonString<DocumentIdentifier>(response.ResponseContent);
            return document;
        }

        public void UpdateInvitation(string uuid, Invitation invitation)
        {
            IRequest request = new ClientHttpPatchRequest<Invitation>(_environment, _responseParser, $"/api/v1/invitation/{uuid}", invitation);
            IResponse response = _client.SendRequest(request);
            if (!response.IsSuccessStatusCode())
            {
                throw new System.Exception("Cannot update invitation");
            }

        }
    }
}
