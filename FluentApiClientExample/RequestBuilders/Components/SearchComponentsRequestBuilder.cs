using System.Collections.Generic;
using RestSharp;

namespace FluentApiClientExample.RequestBuilders.Components
{
    public class SearchComponentsRequestBuilder
    {
        private readonly IRestClient _restClient;

        public SearchComponentsRequestBuilder(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public SearchComponentsRequestBuilderFinal WithQualifiers(
            IEnumerable<ComponentsQualifiers> componentsQualifiers) => new(_restClient, componentsQualifiers);
    }
}