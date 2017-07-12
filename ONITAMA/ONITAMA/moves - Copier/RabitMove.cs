using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.moves
{
    class RabitMove : Move
    {
        public RabitMove()
        {
            name = "Rabit";
            moves = new List<Vector2>();
            moves.Add(new Vector2(-1, 1));
            moves.Add(new Vector2(1, -1));
            moves.Add(new Vector2(2, 0));
        }
    }
}
