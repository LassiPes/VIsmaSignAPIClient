namespace VismaSignClientLib
{
    public interface IHttpClient
    {
         IResponse SendRequest(IRequest request);
    }
}
