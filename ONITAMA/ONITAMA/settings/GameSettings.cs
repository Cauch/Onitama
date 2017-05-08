using ONITAMA.moves;
using ONITAMA.pieces;
using ONITAMA.settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.game
{
    class GameSettings
    {
        private List<Team> teams;
        
        private List<Move> centerMoves;
        private int nbCenterMoves;
        private int width;
        private int height;

        public static GameSettings defaultSettings()
        {
            List<TeamSettings> tsList = new List<TeamSettings>();
            tsList.Add(TeamSettings.defaultTeam1());
            tsList.Add(TeamSettings.defaultTeam2());

            return new GameSettings(new MoveSettings(), tsList, 5, 5, 1);
        }

        public GameSettings(MoveSettings ms, List<TeamSettings> tsList, int width, int height, int nbCenterMoves)
        {
            List<Move> movePool = ms.getMoves();
            Move rngMove;
            Random rng = new Random();

            this.width = width;
            this.height = height;
            this.nbCenterMoves = nbCenterMoves;
            this.centerMoves = new List<Move>();
            this.teams = new List<Team>();

            foreach(TeamSettings ts in tsList)
            {
                this.teams.Add(new Team(ts));

                for (int i = 0; i < ts.getNbMoves(); i++)
                {
                    rngMove = movePool[rng.Next(0, movePool.Count - 1)];
                    this.teams.Last().addMove(rngMove);
                    movePool.Remove(rngMove);
                }
            }

            for (int i = 0; i < nbCenterMoves; i++)
            {
                rngMove = movePool[rng.Next(0, movePool.Count - 1)];
                centerMoves.Add(rngMove);
                movePool.Remove(rngMove);
            }
        }

     
        public List<Team> getTeams() { return teams; }
        public List<Move> getCenterMoves(){ return centerMoves; }
        public int getWidth(){ return width; }
        public int getHeight() { return height; }
    }
}
