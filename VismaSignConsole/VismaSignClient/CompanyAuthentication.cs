using System;
using System.Net.Http.Headers;

namespace VismaSignClientLib
{
    public class CompanyAuthentication: IAuthentication
    {
        private string _scheme;
        private string _identifier;
        private DateTime _date;
        private IHashCalculator _hashCalculator;

        public CompanyAuthentication(string scheme, string clientIdentifier, DateTime date, IHashCalculator hashCalculator)
        {
      
            _scheme = scheme;
            _identifier = clientIdentifier;
            _hashCalculator = hashCalculator;
            _date = date;
        }


        public IRequest AddAuthenticationHeaders(IRequest request)
        {

            if (request.HttpRequestMessage.Content != null)
            {
                request.HttpRequestMessage.Content.Headers.ContentMD5 = _hashCalculator.GetContentMd5(request);
            }

            string mac = _hashCalculator.GetMac(request);
            request.HttpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(_scheme, _identifier + ":" + mac);
            request.HttpRequestMessage.Headers.Date.GetValueOrDefault(_date);
            return request;
        }
    }
}
