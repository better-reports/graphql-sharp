using Newtonsoft.Json;
using System;

namespace GraphQLSharp
{
    public class GraphQLError
    {
        [JsonProperty]
        public string Message { get; private set; }

        [JsonProperty]
        public GraphQLErrorLocation[] Locations { get; private set; }

        [JsonProperty]
        public object[] Path { get; private set; }

        [JsonProperty]
        public dynamic Extensions { get; private set; }
    }
}
