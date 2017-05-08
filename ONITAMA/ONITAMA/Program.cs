using ONITAMA.game;
using ONITAMA.moves;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Grid grid = new Grid(5, 5);

            //Game game = new Game(t, grid, new DragonMove());
            Game game = new Game(GameSettings.defaultSettings());
            do
            {
                game.display();
                Console.WriteLine("Select Piece ");
                Console.WriteLine("Enter x :  ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y :  ");
                y = Convert.ToInt32(Console.ReadLine());

                game.selectPiece(new Vector2(x, y));

                game.display();

                Console.WriteLine("Select Move ");

                Console.WriteLine("Enter number :  ");
                x = Convert.ToInt32(Console.ReadLine());

                game.selectMove(x);
                game.display();

                Console.WriteLine("Enter x :  ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y :  ");
                y = Convert.ToInt32(Console.ReadLine());

            } while (!game.play(new Vector2(x, y)));

            game.display();
            Console.WriteLine("You are winner");
            Console.ReadKey();
        }
    }
}
