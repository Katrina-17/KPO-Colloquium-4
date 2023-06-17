using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPO_Coll.Models
{
    public class Game
    {

        static int currId = 0;

        public enum GameState
        {
            InProcess,
            Finished
        }

        public int Id { get; set; }

        public int Score1stPlayer { get; set; }

        public int Score2ndPlayer { get; set; }

        public GameState State { get; set; }

        public int Id1stPlayer { get; set; }

        public int Id2ndPlayer { get; set; }

        public Game(int id1, int id2)
        {
            Id1stPlayer = id1;
            Id2ndPlayer = id2;

            Score1stPlayer = 0;
            Score2ndPlayer = 0;

            Id = ++currId;

            State = GameState.InProcess;
        }




    }
}
