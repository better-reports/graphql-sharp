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

        public Task<GraphQLResponse<TData, dynamic, dynamic>> PostAsync<TData>(GraphQLRequest r)
        {
            return PostAsync<TData, dynamic, dynamic>(r, CancellationToken.None);
        }

        public Task<GraphQLResponse<TData, TExtensions, dynamic>> PostAsync<TData, TExtensions>(GraphQLRequest r)
        {
            return PostAsync<TData, TExtensions, dynamic>(r, CancellationToken.None);
        }

        public Task<GraphQLResponse<TData, TExtensions, TErrorExtensions>> PostAsync<TData, TExtensions, TErrorExtensions>(GraphQLRequest r)
        {
            return PostAsync<TData, TExtensions, TErrorExtensions>(r, CancellationToken.None);
        }

        public Task<GraphQLResponse<T, dynamic, dynamic>> PostAsync<T>(GraphQLRequest r, T responseAnonymousType)
        {
            return PostAsync<T, dynamic, dynamic>(r, CancellationToken.None);
        }

        public Task<GraphQLResponse<TData, TExtensions, dynamic>> PostAsync<TData, TExtensions>(GraphQLRequest r, TData responseAnonymousType, TExtensions extensionsAnonymousType)
        {
            return PostAsync<TData, TExtensions, dynamic>(r, CancellationToken.None);
        }

        public Task<GraphQLResponse<TData, TExtensions, TErrorExtensions>> PostAsync<TData, TExtensions, TErrorExtensions>(GraphQLRequest r, TData responseAnonymousType, TExtensions extensionsAnonymousType, TErrorExtensions errorExtensionsAnonymousType)
        {
            return PostAsync<TData, TExtensions, TErrorExtensions>(r, CancellationToken.None);
        }

        public async Task<GraphQLResponse<TData, TExtensions, TErrorExtensions>> PostAsync<TData, TExtensions, TErrorExtensions>(GraphQLRequest r, CancellationToken cancellationToken)
        {
            var queryJson = JsonConvert.SerializeObject(r, _serializerSettings);
            var httpContent = new StringContent(queryJson, Encoding.UTF8, "application/json");
            var res = await (_client ?? _clientFactory.CreateClient())
                                          .PostAsync(_uri, httpContent, cancellationToken);
            var responseJson = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GraphQLResponse<TData, TExtensions, TErrorExtensions>>(responseJson, _serializerSettings);
        }
    }
}
