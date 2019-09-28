namespace VismaSignClientLib
{
    public interface IResponse
    {
        bool IsSuccessStatusCode();
        string ResponseContent { get; }
        string Location { get; }
    }
}
