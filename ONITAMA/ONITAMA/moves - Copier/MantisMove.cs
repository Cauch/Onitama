using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.moves
{
    class MantisMove : Move
    {
        public MantisMove()
        {
            name = "Mantis";
            moves = new List<Vector2>();
            moves.Add(new Vector2(0, 1));
            moves.Add(new Vector2(-1, -1));
            moves.Add(new Vector2(1, -1));
        }
    }
}
