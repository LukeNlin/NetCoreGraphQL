using System;
using System.Collections.Generic;
using GraphQLNetCore.Data.Models;

namespace GraphQLNetCore.Data.RepoInterfaces
{
    public interface IPlayerRepository
    {
        Player GetByNumber(int number);
        List<Player> GetAll();
    }
}
