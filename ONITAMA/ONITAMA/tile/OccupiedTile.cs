using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONITAMA.pieces;
using ONITAMA.utils;

namespace ONITAMA.tile
{
    class OccupiedTile : Tile
    {
        private Piece p;
        private Tile oldTile;

        public OccupiedTile(Vector2 v, Piece p, Tile t) : base(v)
        {
            this.p = p;
            this.oldTile = t;
        }

        public override Tile occupy(Piece p)
        {
            this.p = p;
            return this;
        }

        public override object onEnter(Piece p)
        {
            if(oldTile.GetType() == typeof(TempleTile) && (bool)oldTile.onEnter(p))
            {
                return true;
            }
            return this.p;
        }

        public override Tile onLeave()
        {
            return oldTile;
        }

        public Piece getPiece()
        {
            return p;
        }
        
        public Tile getOldTile()
        {
            return oldTile;
        }

        public override void display()
        {
            Console.Write(String.Format("{0}{1}",p.getName()[0],p.getId()));
        }
    }
}
