using System;

namespace GraphQLSharp
{
    public class GraphQLRequest
    {
        public string Query { get; set; }
        public string OperationName { get; set; }

        public GraphQLRequest()
        {
        }

        public GraphQLRequest(string query)
        {
            Query = query;
        }
    }
}
