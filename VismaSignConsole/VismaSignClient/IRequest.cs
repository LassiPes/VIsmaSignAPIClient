using System.Net.Http;

namespace VismaSignClientLib
{
    public interface IRequest
    {
        HttpRequestMessage HttpRequestMessage { get; }
    }
}
