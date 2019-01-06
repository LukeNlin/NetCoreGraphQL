using GraphQL.Types;
using GraphQLNetCore.Data.RepoInterfaces;

namespace GraphQLNetCore.Api.Models
{
    public class PlayerDataQuery : ObjectGraphType
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerDataQuery(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;

            Field<PlayerGraphType>
            (
                "Player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "number" }),
                resolve: _ => _playerRepository.GetByNumber(_.GetArgument<int>("number"))
            );

            Field<ListGraphType<PlayerGraphType>>
            (
                "Players",
                resolve: _ => _playerRepository.GetAll()
            );
        }
    }
}

