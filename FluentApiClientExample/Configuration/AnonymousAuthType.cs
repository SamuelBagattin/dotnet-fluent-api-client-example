using System;
using RestSharp;

namespace FluentApiClientExample.Configuration
{
    public class AnonymousAuthType : AuthType
    {
        private readonly RestClient _restClient;

        internal AnonymousAuthType(RestClient restClient)
        {
            _restClient = restClient;
        }

        internal override void Verify()
        {
            Console.WriteLine("Verifying Authentication");
        }

        internal override RestClient GetRestClient() => _restClient;
    }

}