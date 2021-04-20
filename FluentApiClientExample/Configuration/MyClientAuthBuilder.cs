using RestSharp;

namespace FluentApiClientExample.Configuration
{
    public class MyClientAuthBuilder
    {
        private readonly RestClient _restClient;
        
        public MyClientAuthBuilder(RestClient restClient)
        {
            _restClient = restClient;
        }
        
        public TokenAuthType WithTokenAuth(string token) => new(_restClient, token);
        
        public AnonymousAuthType WithAnonymousAuth => new(_restClient);
    }


}