using Newtonsoft.Json;
using System;

namespace GraphQLSharp
{
    public class GraphQLResponse<TData, TExtensions, TErrorExtensions>
    {
        [JsonProperty]
        public TData Data { get; private set; }

        [JsonProperty]
        public GraphQLError<TErrorExtensions>[] Errors { get; private set; }

        [JsonProperty]
        public TExtensions Extensions { get; private set; }
    }
}
