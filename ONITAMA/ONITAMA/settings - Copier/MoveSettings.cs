using ONITAMA.moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.settings
{
    class MoveSettings
    {
        private List<Move> moves;

        public MoveSettings()
        {
            moves = new List<Move>();
            addMove(new BoarMove());
            addMove(new CobraMove());
            addMove(new CrabMove());
            addMove(new CraneMove());
            addMove(new DragonMove());
            addMove(new EelMove());
            addMove(new ElephantMove());
            addMove(new FrogMove());
            addMove(new GooseMove());
            addMove(new HorseMove());
            addMove(new MantisMove());
            addMove(new MonkeyMove());
            addMove(new OxMove());
            addMove(new RabitMove());
            addMove(new RoosterMove());
            addMove(new TigerMove());
        }

        public List<Move> getMoves()
        {
            return moves;
        }

        public void addMove(Move m)
        {
            moves.Add(m);
        }

        public void removeMove(Move m)
        {
            moves.Remove(m);
        }
    }
}
