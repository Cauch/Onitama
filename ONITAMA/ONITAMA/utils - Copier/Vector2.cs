using ONITAMA.moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.utils
{
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator+(Vector2 v1, Vector2 v2)
        {
            Vector2 v3;
            v3.x = v2.x + v1.x;
            v3.y = v2.y + v1.y;
            return v3;
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            Vector2 v3;
            v3.x = v2.x * v1.x;
            v3.y = v2.y * v1.y;
            return v3;
        }

        public static Move operator *(Vector2 v, Move m)
        {
            Move m2 = m;
            List<Vector2> newMoves = new List<Vector2>();
            foreach(Vector2 vTemp in m.getMoves()){
                newMoves.Add(vTemp * v);
            }
            m2.setMoves(newMoves);
            return m2;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            Vector2 v3;
            v3.x = v2.x - v1.x;
            v3.y = v2.y - v1.y;
            return v3;
        }
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return v1.x != v2.x || v1.y != v2.y;
        }

        public String toString()
        {
            return String.Format("({0},{1})", x, y);
        }
    }
}
