using ONITAMA.moves;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.pieces
{
    abstract class Piece
    {
        protected String name;
        protected Vector2 position;
        protected int id;

        public Piece(Vector2 v, int id)
        {
            this.position = v;
            this.id = id;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public void setPosition(Vector2 v)
        {
            this.position = v;
        }

        public Vector2 move(Vector2 v)
        {
            position = position + v;
            return position;
        }

        public Vector2 counterMove(Vector2 v)
        {
            position = position - v;
            return position;
        }

        public String getName()
        {
            return this.name;
        }

        public int getId()
        {
            return this.id;
        }

        public void info()
        {
            Console.WriteLine(String.Format("Name: {0}, {1}", name, position.toString()));
        }
    }
}
