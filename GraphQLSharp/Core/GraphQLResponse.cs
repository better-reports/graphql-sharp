using Newtonsoft.Json;
using System;

namespace GraphQLSharp
{
    public class GraphQLResponse<T>
    {
        [JsonProperty]
        public T Data { get; private set; }

        [JsonProperty]
        public GraphQLError[] Errors { get; private set; }

        [JsonProperty]
        public dynamic Extensions { get; private set; }
    }
}
