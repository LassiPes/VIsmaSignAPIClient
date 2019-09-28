namespace VismaSignClientLib
{
    public class EnvironmentStaging : IEnvironment
    {
        public string Root
        {
            get
            {
                return "https://sign-staging.visma.net";
            }
        }
    }
}
