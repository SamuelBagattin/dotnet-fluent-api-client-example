using System;
using FluentApiClientExample.RequestBuilders;
using FluentApiClientExample.Requests;

namespace FluentApiClientExample
{
    public interface IMyClient
    {
        IAsyncRequest<T> MakeRequest<T>(Func<ApiRequestBuilder, RequestBuilder<IAsyncRequest<T>>> requestBuilder);
    }
}