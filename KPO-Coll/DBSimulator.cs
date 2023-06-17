using KPO_Coll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPO_Coll
{
    public static class DBSimulator
    {

        static List<Game> games = new();
        static List<Player> players = new();

        public static int AddGame(Game game)
        {
            games.Add(game);
            return 0;
        } 


        public static int AddPlayer(Player player)
        {
            var res = (from pl in players where pl.Id == player.Id select pl).Count();
            if (res == 0)
            {
                players.Add(player);
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static List<Game> GetGames()
        {
            return (from g in games select g).ToList();
        }

        public static List<Player> GetPlayers()
        {
            return (from p in players select p).ToList();
        }


    }
}
