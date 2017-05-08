using ONITAMA.exception;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ONITAMA.moves
{
    abstract class Move
    {
        protected List<Vector2> moves;
        protected String name;

        public Vector2 select(Vector2 v)
        {
            foreach(Vector2 m in moves){
                if(m==v)
                {
                    return m;
                }
            }
            throw new NotInListException(String.Format("The move : ({0},{1}) is not a valid move",v.x,v.y));
        }

        public List<Vector2> getMoves()
        {
            return moves;
        }

        public void setMoves(List<Vector2> moves)
        {
            this.moves = moves;
        }

        //For test purposes
        public void info()
        {
            
            foreach(Vector2 m in moves)
            {
                Console.WriteLine(m.toString());
            }
        }
        public void display()
        {
            Console.WriteLine(name);
            for (int y = -2; y < 3; y++)
            {
                for (int x = -2; x < 3; x++)
                {
                    if (moves.Contains(new Vector2(x, y)))
                    {
                        Console.Write("X");
                    }
                    else if (x == 0 && y == 0)
                    {
                        Console.Write("O");
                    }
                    else {
                        Console.Write("_");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
