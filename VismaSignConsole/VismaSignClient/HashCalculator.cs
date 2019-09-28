using System;
using System.Security.Cryptography;
using System.Text;

namespace VismaSignClientLib
{
    public class HashCalculator: IHashCalculator
    {
        private HashAlgorithm _macHash;
        private HashAlgorithm _contentHash;
        private string _root;
        public HashCalculator(string secret, string root)
        {
            _macHash = new HMACSHA512(Convert.FromBase64String(secret));
            _contentHash = new MD5CryptoServiceProvider();
            _root = root;
        }

        public string GetMac(IRequest request)
        {
            string[] hashParts = new string[] {
                request.HttpRequestMessage.Method.ToString(),
                Convert.ToBase64String(request.HttpRequestMessage.Content != null ? GetContentMd5(request) : _contentHash.ComputeHash(new byte[] {})),
                request.HttpRequestMessage.Content != null ? request.HttpRequestMessage.Content.Headers.ContentType.ToString() : "",
                request.HttpRequestMessage.Headers.Date.GetValueOrDefault(DateTime.UtcNow).ToString("r"),
                request.HttpRequestMessage.RequestUri.ToString().Replace(_root, "")
            };
            return Convert.ToBase64String(_macHash.ComputeHash(Encoding.UTF8.GetBytes(String.Join("\n", hashParts))));

        }

        public byte[] GetContentMd5(IRequest request)
        {
            return _contentHash.ComputeHash(request.HttpRequestMessage.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult());
        }
    }
}
