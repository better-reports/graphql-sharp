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

        private const string _querySyntaxError = @"{{ 
                                                    allFilms
                                                  {
                                                    totalCount
                                                  }
                                                }";

        private readonly GraphQLClient _starWarsClient = new GraphQLClient(new HttpClient(), new Uri("https://swapi.apis.guru"));

        [TestMethod]
        public async Task QueryDynamic()
        {
            var res = await _starWarsClient.QueryAsync<dynamic>(new GraphQLRequest(_queryAllFilms));
            Assert.IsTrue(res.Data.allFilms.totalCount > 0);
        }

        [TestMethod]
        public async Task QueryAnonymous()
        {
            var res = await _starWarsClient.QueryAsync(new GraphQLRequest(_queryAllFilms),
                                                                                    new
                                                                                    {
                                                                                        AllFilms = new
                                                                                        {
                                                                                            TotalCount = default(int),
                                                                                        }
                                                                                    });
            Assert.IsTrue(res.Data.AllFilms.TotalCount > 0);
        }

        [TestMethod]
        public async Task QueryDynamicError()
        {
            var res = await _starWarsClient.QueryAsync<dynamic>(new GraphQLRequest(_querySyntaxError));
            Assert.IsTrue(res.Errors.Length > 0);
            Assert.IsTrue(res.Errors[0].Locations.Length > 0);
            Assert.IsTrue(res.Errors[0].Locations[0].Line > 0);
            Assert.IsTrue(res.Errors[0].Locations[0].Column > 0);
            Assert.IsTrue(res.Errors[0].Message != null);
        }
    }
}
