using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPO_Coll.Models
{
    public class GameRequest
    {

        /// <summary>
        /// Увеличение счёта 1го игрока этим ходом-запросом
        /// </summary>
        public int FirstPlayerPlusScore { get; set; }

        /// <summary>
        /// Увеличение счёта 2го игрока этим ходом-запросом
        /// </summary>
        public int SecondPlayerPlusScore { get; set; }

        // Если оба PlusScore = 0 => конец игры.


    }
}
