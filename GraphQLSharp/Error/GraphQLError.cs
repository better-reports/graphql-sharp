using Newtonsoft.Json;
using System;

namespace GraphQLSharp
{
    public class GraphQLError<TExtensions>
    {
        [JsonProperty]
        public string Message { get; private set; }

        [JsonProperty]
        public GraphQLErrorLocation[] Locations { get; private set; }

        [JsonProperty]
        public object[] Path { get; private set; }

        [JsonProperty]
        public TExtensions Extensions { get; private set; }
    }
}
