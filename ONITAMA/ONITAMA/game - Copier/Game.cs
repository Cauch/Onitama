using ONITAMA.exception;
using ONITAMA.moves;
using ONITAMA.pieces;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.game
{
    class Game
    {
        private List<Team> teams;
        int turn = 0;
        private Grid grid;
        Move centerMove;
        private Piece selectedPiece;
        private Move selectedMove;
        private int nbTeams;

        public Game(GameSettings gs)
        {
            this.teams = gs.getTeams();
            this.nbTeams = this.teams.Count;
            this.centerMove = gs.getCenterMoves()[0];
            this.grid = new Grid(gs.getWidth(), gs.getHeight());

            selectedPiece = null;
            selectedMove = null;

            grid.init(teams);
        }
        public Piece selectPiece(Vector2 position)
        {
            
            foreach(Piece p in teams[turn % nbTeams].getPieces())
            {
                if(p.getPosition() == position)
                {
                    this.selectedPiece = p;
                    setSelectionToGrid();
                    return p;
                }
            }
            return null;
        }

        // Might need review here
        public Move selectMove(int i)
        {
            this.selectedMove = teams[turn % nbTeams].getMoves()[i];
            setSelectionToGrid();
            return selectedMove;
        }

        public void setSelectionToGrid()
        {
            if(selectedPiece != null)
            {
                grid.selectTile(selectedPiece.getPosition());
                if(selectedMove != null)
                {
                    foreach(Vector2 v in selectedMove.getMoves())
                    {
                        grid.setMovingToTile(selectedPiece.getPosition()+v, teams[turn % nbTeams].getId());
                    }
                    
                }
            }
        }

        public bool play(Vector2 v)
        {
            bool win = false;
            if (selectedPiece != null && selectedMove != null) //Move takes place
            {
                object o = grid.transfer(selectedPiece.getPosition(), v);
                selectedPiece.setPosition(v);
               if(o.GetType().IsSubclassOf(typeof(Piece)))
                {
                    teams[((Piece)o).getId()].removePiece(((Piece)o));
                    win = true;
                    foreach(Piece p in teams[((Piece)o).getId()].getPieces())
                    {
                        if(p.GetType() == typeof(Master))
                        {
                            win = false;
                            break;
                        }
                    }
                } else if(o.GetType() == typeof(bool))
                {
                    win = (bool)o;
                }

                //End turn
                centerMove = teams[turn % nbTeams].replace(selectedMove, centerMove);

                selectedMove = null;
                selectedPiece = null;

                grid.unselectAll();
                turn++;
                
            }
            return win;
        }

        //Testing purposes
        public void display()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("********Team {0} Moves**********", teams[0].getId() + 1);
            foreach (Move m in teams[0].getMoves())
            {
                m.display();
            }
            Console.WriteLine("********************************");

            grid.display();
            Console.WriteLine("********************************");
            Console.WriteLine("********Team {0} Moves**********", teams[1].getId() + 1);
            foreach (Move m in teams[1].getMoves())
            {
                m.display();
            }
            Console.WriteLine("********************************");
        }
    }
}
