using System;
using System.Runtime.Serialization;
using System.Text;

namespace Jumio.Api
{
    [DataContract]
    public class Configuration : AspNet.WebApi.Configuration
    {
        [DataMember(Name = "user-agent")]
        public UserAgentConfiguration UserAgent { get; set; }

        public CredentialsConfiguration Credentials { get; set; }

        public string GetTransactionsCredentials() => GetCredentials(Credentials.Transactions.User, Credentials.Transactions.Password);

        public string GetAdministrationCredentials() => GetCredentials(Credentials.Administration.User, Credentials.Administration.Password);

        public class CredentialsConfiguration
        {
            public TransactionConfiguration Transactions { get; set; }
            public AdministrationConfiguration Administration { get; set; }

            public class TransactionConfiguration : CredentialConfiguration { }

            public class AdministrationConfiguration : CredentialConfiguration { }

            public class CredentialConfiguration
            {
                public string User { get; set; }

                public string Password { get; set; }
            }
        }

        [DataContract]
        public class UserAgentConfiguration
        {
            public string ProductName { get; set; }

            public string ProductVersion { get; set; }
        }

        private string GetCredentials(string user, string password) => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));
    }
}
