using ONITAMA.pieces;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.tile
{
    abstract class Tile
    {
        protected Vector2 position;
        protected State state;
        public Tile(Vector2 v)
        {
            this.position = v;
            state = State.UNSELECTED;
        }
        
        public State getState()
        {
            return state;
        }
        public void setState(State state)
        {
            this.state = state;
        }
        public abstract object onEnter(Piece p);
        public abstract Tile onLeave();
        public abstract Tile occupy(Piece p);
        //Testing purposes
        public abstract void display();
    }
}
