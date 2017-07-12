using ONITAMA.moves;
using ONITAMA.pieces;
using ONITAMA.settings;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.game
{
    class Team
    {
        private List<Piece> pieces;
        private Vector2 transformMove;
        private List<Move> moves;
        private String name;
        private int id;
        //private color;

        //Temporary, base game settings
        public Team(String name, List<Move> moves, int id)
        {
            this.name = name;
            this.id = id;
            if (name == "BLUE")
            {
                transformMove = new Vector2(-1, -1);
                pieces = new List<Piece>();
                pieces.Add(new Acolyte(new Vector2(0, 0), id));
                pieces.Add(new Acolyte(new Vector2(1, 0), id));
                pieces.Add(new Master(new Vector2(2, 0), id));
                pieces.Add(new Acolyte(new Vector2(3, 0), id));
                pieces.Add(new Acolyte(new Vector2(4, 0), id));

            }
            else if (name == "RED")
            {
                transformMove = new Vector2(1, 1);
                pieces = new List<Piece>();
                pieces.Add(new Acolyte(new Vector2(0, 4), id));
                pieces.Add(new Acolyte(new Vector2(1, 4), id));
                pieces.Add(new Master(new Vector2(2, 4), id));
                pieces.Add(new Acolyte(new Vector2(3, 4), id));
                pieces.Add(new Acolyte(new Vector2(4, 4), id));
            }

            this.moves = new List<Move>();
            foreach (Move m in moves) {
                this.moves.Add(transformMove * m);
            }

        }

        public Team(TeamSettings ts)
        {
            this.name = ts.getName();
            this.id = ts.getId();
            this.pieces = ts.getPieces();
            this.moves = new List<Move>();
            this.transformMove = ts.getTransform();
        }

        public int getId()
        {
            return this.id;
        }

        public List<Piece> getPieces()
        {
            return this.pieces;
        }

        public List<Move> getMoves()
        {
            return this.moves;
        }

        public void addPiece(Piece p)
        {
            pieces.Add(p);
        }

        public void removePiece(Piece p)
        {
            pieces.Remove(p);
        }
        public void addMove(Move m)
        {
            moves.Add(m);
        }

        public void removeMove(Move m)
        {
            moves.Remove(m);
        }

        public Move replace(Move before, Move after)
        {
            moves.Remove(before);
            moves.Add(transformMove*after);
            return transformMove*before;
        }
    }
}
