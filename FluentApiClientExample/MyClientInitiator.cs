using System;
using FluentApiClientExample.Configuration;

namespace FluentApiClientExample
{
    public static class MyClientInitiator
    {
        public static IMyClient NewClient(
            Func<MyClientBaseUrlBuilder, AuthType> clientBuilder)
        {
            var authentication = clientBuilder(new MyClientBaseUrlBuilder());
            authentication.Verify();
            return new MyClient(authentication.GetRestClient());
        }
    }

}