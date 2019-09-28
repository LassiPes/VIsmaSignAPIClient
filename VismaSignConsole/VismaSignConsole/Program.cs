using System;
using System.Net;
using VismaSignClientLib;

namespace VismaSignConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = " jp7SjOOr4czRTifCo30qx0sZAIw9PW+vVpsbP09pQaY=";
            string scheme = "Onnistuu";
            string clientIdentifier = "ddf58116-6082-4bfc-a775-0c0bb2f945ce";
            IEnvironment environment = new EnvironmentStaging();
            IHashCalculator hashCalculator = new HashCalculator(secret, environment.Root);
            IAuthentication authentication = new CompanyAuthentication(scheme, clientIdentifier, DateTime.Now, hashCalculator);
            IResponseParser responseParser = new ResponseParser();
            VismaSignClient client = new VismaSignClient(authentication, environment, responseParser);



            var documentUri = client.DocumentCreate(new DocumentInfo() { document = new DocumentInfo.DocumentData() { name = "Test doc" } });

            WebClient webClient = new WebClient();
            byte[] fileContent = webClient.DownloadData("https://sign.visma.net/empty.pdf");

            client.DocumentAddFile(documentUri, fileContent, "test.pdf");

        }
    }
} 
