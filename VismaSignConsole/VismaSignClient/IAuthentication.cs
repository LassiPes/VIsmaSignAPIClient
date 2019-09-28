namespace VismaSignClientLib
{
    public interface IAuthentication
    {
        IRequest AddAuthenticationHeaders(IRequest request);
    }
}
