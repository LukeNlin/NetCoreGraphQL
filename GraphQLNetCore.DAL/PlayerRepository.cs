using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphQLNetCore.Data.Models;
using GraphQLNetCore.Data.RepoInterfaces;

namespace GraphQLNetCore.DAL
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<Player> _players;

        public PlayerRepository()
        {
            _players = new List<Player>();
            LoadData();
        }

        public Player GetByNumber(int number)
        {
            return _players.Where(x => x.Number == number).FirstOrDefault();
        }

        public List<Player> GetAll()
        {
            return _players;
        }

        //Load from file for now
        private void LoadData()
        {
            var file = new StreamReader(@"..\Players.txt");

            var input = string.Empty;

            while ((input = file.ReadLine()) != null)
            {
                var result = input.Split(',');

                var player = new Player
                {
                    Number = Convert.ToInt32(result[0]),
                    Name = result[1],
                    Nationality = result[2],
                    Age = Convert.ToInt32(result[3])
                };

                _players.Add(player);
            }
        }
    }
}
