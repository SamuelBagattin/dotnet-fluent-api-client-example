using System;
using RestSharp;

namespace FluentApiClientExample.Configuration
{
    public class MyClientBaseUrlBuilder
    {
        public MyClientAuthBuilder WithBaseUrl(string baseUri) => new(new RestClient(new Uri(baseUri)));
    }

}