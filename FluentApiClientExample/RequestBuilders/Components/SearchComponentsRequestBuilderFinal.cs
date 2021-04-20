using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentApiClientExample.Requests;
using RestSharp;

namespace FluentApiClientExample.RequestBuilders.Components
{
    public enum ComponentsQualifiers
    {
        Trk
    }


    public class SearchComponentsRequestBuilderFinal : RequestBuilder<IAsyncRequest<SearchComponentsResponse>>
    {
        private uint? _page;
        private uint? _pageSize;
        private string _query;
        private readonly IEnumerable<ComponentsQualifiers> _qualifiers;

        private readonly IRestClient _restClient;

        internal SearchComponentsRequestBuilderFinal(IRestClient restClient, IEnumerable<ComponentsQualifiers> componentsQualifiers)
        {
            _restClient = restClient;
            _qualifiers = componentsQualifiers;
        }

        public SearchComponentsRequestBuilderFinal PageNumber(uint page)
        {
            _page = page;
            return this;
        }

        public SearchComponentsRequestBuilderFinal PageSize(uint pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public SearchComponentsRequestBuilderFinal Query(string query)
        {
            _query = query;
            return this;
        }

        private string GetQualifierName(ComponentsQualifiers componentsQualifiers)
        {
            return componentsQualifiers switch
            {
                ComponentsQualifiers.Trk => "TRK",
                _ => throw new ArgumentOutOfRangeException(nameof(componentsQualifiers), componentsQualifiers, null)
            };
        }


        
        internal override SearchComponentsAsyncRequest Build()
        {
            Console.WriteLine("Making request validation");
            var req = new RestRequest("api/components/search", Method.GET)
                .AddQueryParameter("qualifiers", string.Join(",",_qualifiers.Select(GetQualifierName)));
            if (_page is not null)
            {
                req = req.AddQueryParameter("p",_page.ToString());
            }

            if (_pageSize is not null)
            {
                req = req.AddQueryParameter("ps", _pageSize.ToString());
            }

            if (_query is not null)
            {
                req = req.AddQueryParameter("q", _query);
            }
            return new SearchComponentsAsyncRequest(_restClient, req);
        }
    }

}