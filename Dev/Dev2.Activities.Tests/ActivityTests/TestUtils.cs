using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dev2.Runtime.ServiceModel.Data;

namespace Dev2.Tests.Activities.ActivityTests
{
    [ExcludeFromCodeCoverage]
    public static class TestUtils
    {
        public static WebSource CreateWebSourceWithCredentials()
        {
            return new WebSource()
            {
                AuthenticationType = AuthenticationType.User,
                Password = "Passwr1",
                UserName = "User1",
                Address = ExampleUri
            };
        }

        public const string ExampleUri = "http://www.example.com";

        public static WebSource CreateWebSourceWithAnonymousAuthentication()
        {
            return new WebSource()
            {
                Password = "PasJun1",
                UserName = "User1",
                AuthenticationType = AuthenticationType.Anonymous,
                Address = ExampleUri
            };
        }

        public static  string ToCleanString(this string value)
        {
            var cleanString = new StringBuilder(value).Replace(Environment.NewLine, "\n").Replace("\r", "\n");
            return cleanString.ToString();
        }
    }
}