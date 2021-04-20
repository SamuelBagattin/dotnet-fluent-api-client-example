using FluentApiClientExample.RequestBuilders.Components;
using RestSharp;

namespace FluentApiClientExample.RequestBuilders
{
    public class ApiRequestBuilder
    {
        private readonly IRestClient _restClient;

        public ApiRequestBuilder(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public SearchComponentsRequestBuilder GetProjects => new(_restClient);
    }

}