using RestSharp;

namespace FluentApiClientExample.Configuration
{
    public abstract class AuthType
    {
        internal abstract void Verify();

        internal abstract RestClient GetRestClient();
    }

}