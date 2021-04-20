using System;
using RestSharp;
using RestSharp.Authenticators;

namespace FluentApiClientExample.Configuration
{
    public class TokenAuthType : AuthType
    {
        private readonly RestClient _restClient;
        private string Token { get; }

        internal TokenAuthType(RestClient restClient, string token)
        {
            _restClient = restClient;
            Token = token;
        }

        internal override void Verify()
        {
            if (Token is null) throw new Exception("Token is null");
        }

        internal override RestClient GetRestClient()
        {
            _restClient.Authenticator = new HttpBasicAuthenticator(Token, "");
            return _restClient;
        }
    }

}