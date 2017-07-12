using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.moves
{
    class GooseMove : Move
    {
        public GooseMove()
        {
            name = "Goose";
            moves = new List<Vector2>();
            moves.Add(new Vector2(-1, 0));
            moves.Add(new Vector2(-1, -1));
            moves.Add(new Vector2(1, 0));
            moves.Add(new Vector2(1, 1));
        }
    }
}
