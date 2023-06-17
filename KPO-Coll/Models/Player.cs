using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPO_Coll.Models
{
    public class Player
    {

        static int currId = 0;

        int numVictories;
        int numLosses;

        public int Id { get; set; }

        public Player()
        {
            Id = ++currId;
            numVictories = 0;
            numLosses = 0;
        }

        public void AddVictory() => numVictories++;
        public void AddLoss() => numLosses++;

        public string Statistics
        {
            get => $"Victories: {numVictories}, Losses: {numLosses}";
        }

    }
}
