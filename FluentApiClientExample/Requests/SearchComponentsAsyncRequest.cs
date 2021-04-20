using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace FluentApiClientExample.Requests
{
    public class SearchComponentsAsyncRequest : IAsyncRequest<SearchComponentsResponse>
    {
        private readonly IRestClient _restClient;
        private readonly IRestRequest _restRequest;
        public SearchComponentsAsyncRequest(IRestClient restClient, IRestRequest restRequest)
        {
            _restClient = restClient;
            _restRequest = restRequest;
        }
        public async Task<SearchComponentsResponse> Execute(CancellationToken cancellationToken = default)
        {
            var truc = await _restClient.ExecuteAsync<SearchComponentsResponse>(_restRequest, cancellationToken);
            return truc.Data;
        }
    }



    public class SearchComponentsResponse
    {
        public PagingResponse Paging { get; set; }
        public List<Component> Components { get; set; }
    }

    public class PagingResponse
    {
        public uint PageIndex { get; set; } 
        public uint PageSize { get; set; }
        public uint Total { get; set; }
    };

    public class Component
    {
        public string Key { get; set; } 
        public string Name { get; set; } 
        public string Qualifier { get; set; } 
        public string Project { get; set; }
    };
}