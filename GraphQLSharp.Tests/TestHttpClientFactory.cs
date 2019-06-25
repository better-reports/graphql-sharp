using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GraphQLSharp.Tests
{
    public class TestHttpClientFactory : IHttpClientFactory
    {
        private HttpClient _client = new HttpClient();

        public HttpClient CreateClient(string name)
        {
            return _client;
        }
    }
}
