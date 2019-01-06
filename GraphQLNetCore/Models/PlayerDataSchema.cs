using GraphQL;
using GraphQL.Types;

namespace GraphQLNetCore.Api.Models
{
    public class PlayerDataSchema : Schema
    {
        public PlayerDataSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PlayerDataQuery>();
        }
    }
}

