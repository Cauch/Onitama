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
    class ObstacleTile : Tile
    {
        public ObstacleTile(Vector2 v) : base(v) { }
        public override void display()
        {
            Console.Write("-!-");
        }

        public override Tile occupy(Piece p)
        {
            throw new ObstacleException();
        }

        public override object onEnter(Piece p)
        {
            throw new NotImplementedException();
        }

        public override Tile onLeave()
        {
            throw new CannotLeaveException("Obstacle tiles cannot be leaved");
        }
    }
}
