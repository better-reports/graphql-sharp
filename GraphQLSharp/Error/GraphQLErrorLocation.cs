using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLSharp
{
    public class GraphQLErrorLocation
    {
        [JsonProperty]
        public uint Column { get; private set; }

        [JsonProperty]
        public uint Line { get; private set; }
    }
}
