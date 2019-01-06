using GraphQL.Types;
using GraphQLNetCore.Data.Models;

public class PlayerGraphType : ObjectGraphType<Player>
{
    public PlayerGraphType()
    {
        Field(x => x.Name);
        Field(x => x.Number);
        Field(x => x.Nationality);
        Field(x => x.Age);
    }
}