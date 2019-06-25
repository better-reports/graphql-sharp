using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphQLSharp.Tests
{
    [TestClass]
    public class QueryTests
    {
        private const string _queryAllFilms = @"{
                                                  allFilms
                                                  {
                                                    totalCount
                                                  }
                                                }";

        [TestMethod]
        public async Task QueryAnonymous()
        {
            var client = new GraphQLClient(new HttpClient(), new Uri("https://swapi.apis.guru"));
            var res = await client.QueryAsync(new GraphQLRequest(_queryAllFilms),
                                                                                    new
                                                                                    {
                                                                                        allFilms = new
                                                                                        {
                                                                                            totalCount = default(int),
                                                                                        }
                                                                                    });
            Assert.IsTrue(res.Data.allFilms.totalCount > 0);
        }

        [TestMethod]
        public async Task QueryDynamic()
        {
            var client = new GraphQLClient(new HttpClient(), new Uri("https://swapi.apis.guru"));
            var res = await client.QueryAsync<dynamic>(new GraphQLRequest(_queryAllFilms));
            Assert.IsTrue(res.Data.allFilms.totalCount > 0);
        }
    }
}
