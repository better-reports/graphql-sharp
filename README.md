# GraphQLSharp
A simple GraphQL client for .NET


```csharp
string _queryAllFilms = @"{
                                allFilms
                                {
                                totalCount
                                }
                            }";
var starWarsClient = new GraphQLClient(new HttpClient(), new Uri("https://swapi.apis.guru"));
var res = await starWarsClient.PostAsync<dynamic>(new GraphQLRequest(_queryAllFilms));
Assert.IsTrue(res.Data.allFilms.totalCount > 0);//res.Data is of type dynamic

var res2 = await _starWarsClient.PostAsync(new GraphQLRequest(_queryAllFilms),
                                                                        new
                                                                        {
                                                                            AllFilms = new
                                                                            {
                                                                                TotalCount = default(int),
                                                                            }
                                                                        });
Assert.IsTrue(res2.Data.AllFilms.TotalCount > 0);//res.Data is strongly typed with the given anonymous type!
```