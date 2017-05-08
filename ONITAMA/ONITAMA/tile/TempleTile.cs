using ONITAMA.pieces;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.tile
{
    class TempleTile : EmptyTile
    {
        private int id;
        public TempleTile(Vector2 v, int id) : base(v) {
            this.id = id;
        }
        public override object onEnter(Piece p)
        {
            return p.GetType() == typeof(Master) && p.getId() == this.id;
        }

        public override void display()
        {
            Console.Write("-T-");
        }

    }
}
