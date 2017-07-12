using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.pieces
{
    class Master : Piece
    {
        public Master(Vector2 v, int id): base(v, id)
        {
            name = "MASTER";
        }
    }
}
