using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLSharp
{
    public class GraphQLClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;
        private readonly Uri _uri;
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public GraphQLClient(HttpClient client, Uri uri)
        {
            _client = client;
            _uri = uri;
        }

        public GraphQLClient(IHttpClientFactory clientFactory, Uri uri)
        {
            _clientFactory = clientFactory;
            _uri = uri;
        }

        public Task<GraphQLResponse<T>> QueryAsync<T>(GraphQLRequest r, T responseShape)
        {
            return QueryAsync<T>(r, CancellationToken.None);
        }

        public Task<GraphQLResponse<T>> QueryAsync<T>(GraphQLRequest r)
        {
            return QueryAsync<T>(r, CancellationToken.None);
        }

        public async Task<GraphQLResponse<T>> QueryAsync<T>(GraphQLRequest r, CancellationToken cancellationToken)
        {
            var queryJson = JsonConvert.SerializeObject(r, _serializerSettings);
            var httpContent = new StringContent(queryJson, Encoding.UTF8, "application/json");
            var res = await (_client ?? _clientFactory.CreateClient())
                                          .PostAsync(_uri, httpContent, cancellationToken);
            var responseJson = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GraphQLResponse<T>>(responseJson, _serializerSettings);
        }
    }
}
