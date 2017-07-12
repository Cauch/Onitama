using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONITAMA.pieces;
using ONITAMA.exception;
using ONITAMA.utils;

namespace ONITAMA.tile
{
    class EmptyTile : Tile
    {
        public EmptyTile(Vector2 v) : base(v) { }
        public override void display()
        {
            Console.Write("__");
        }

        public override Tile occupy(Piece p)
        {
            return new OccupiedTile(position, p, this);
        }

        public override object onEnter(Piece p)
        {
            return new NullObject();
        }

        public override Tile onLeave()
        {
            throw new CannotLeaveException("Empty tile cannot be leaved");
        }
    }
}
