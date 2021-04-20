using System;
using FluentApiClientExample.RequestBuilders;
using FluentApiClientExample.Requests;
using RestSharp;

namespace FluentApiClientExample
{
    public class MyClient : IMyClient
    {
        private readonly RestClient _restClient;

        public MyClient(RestClient restClient)
        {
            _restClient = restClient;
        }

        public IAsyncRequest<T> MakeRequest<T>(Func<ApiRequestBuilder, RequestBuilder<IAsyncRequest<T>>> requestBuilder)
        {
            var req = requestBuilder(new ApiRequestBuilder(_restClient)).Build();
            Console.WriteLine($"Making request");
            return req;
        }
    }

}