using ONITAMA.pieces;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.settings
{
    class TeamSettings
    {
        private List<Piece> pieces;
        private Vector2 transformMove;
        private String name;
        private int id;
        private int nbMoves;

        public TeamSettings(List<Piece> pieces, Vector2 transformMove, String name, int id, int nbMoves)
        {
            this.pieces = pieces;
            this.transformMove = transformMove;
            this.name = name;
            this.id = id;
            this.nbMoves = nbMoves;
        }

        public static TeamSettings defaultTeam1()
        {
            String name = "BLUE";
            int id = 1;
            Vector2 transformMove = new Vector2(-1, -1);

            List<Piece> pieces = new List<Piece>();

            pieces.Add(new Acolyte(new Vector2(0, 0), id));
            pieces.Add(new Acolyte(new Vector2(1, 0), id));
            pieces.Add(new Master(new Vector2(2, 0), id));
            pieces.Add(new Acolyte(new Vector2(3, 0), id));
            pieces.Add(new Acolyte(new Vector2(4, 0), id));

            int nbMoves = 2;

            return new TeamSettings(pieces,transformMove,name,id,nbMoves);
        }

        public static TeamSettings defaultTeam2()
        {
            String name = "RED";
            int id = 2;
            Vector2 transformMove = new Vector2(1, 1);

            List<Piece> pieces = new List<Piece>();

            pieces.Add(new Acolyte(new Vector2(0, 4), id));
            pieces.Add(new Acolyte(new Vector2(1, 4), id));
            pieces.Add(new Master(new Vector2(2, 4), id));
            pieces.Add(new Acolyte(new Vector2(3, 4), id));
            pieces.Add(new Acolyte(new Vector2(4, 4), id));

            int nbMoves = 2;

            return new TeamSettings(pieces, transformMove, name, id, nbMoves);
        }

        public List<Piece> getPieces()
        {
            return pieces;
        }

        public void addPiece(Piece p)
        {
            pieces.Add(p);
        }

        public void removePiece(Piece p)
        {
            pieces.Remove(p);
        }

        public Vector2 getTransform()
        {
            return this.transformMove;
        }

        public void setTransform(Vector2 v)
        {
            this.transformMove = v;
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String s)
        {
            this.name = s;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int i)
        {
            this.id = i;
        }

        public int getNbMoves()
        {
            return this.nbMoves;
        }

        public void setNbMoves(int i)
        {
            this.nbMoves = i;
        }
    }
}
