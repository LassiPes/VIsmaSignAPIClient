namespace VismaSignClientLib
{
    public class EnvironmentProduction : IEnvironment
    {
        public string Root
        {
            get
            {
                return "https://sign.visma.net";
            }
        }
    }
}
