using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.moves
{
    class CrabMove : Move
    {
        public CrabMove()
        {
            name = "Crab";
            moves = new List<Vector2>();
            moves.Add(new Vector2(-2, 0));
            moves.Add(new Vector2(2, 0));
            moves.Add(new Vector2(0, -1));
        }
    }
}
