using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.moves
{
    class CustomMove : Move
    {
        public CustomMove(List<Vector2> moves)
        {
            this.moves = new List<Vector2>();
            this.moves = moves;
        }

        public void addMove(Vector2 v)
        {
            moves.Add(v);
        }

        public void removeMove(Vector2 v)
        {
            moves.Remove(v);
        }
    }
}
