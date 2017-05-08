using ONITAMA.pieces;
using ONITAMA.tile;
using ONITAMA.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.game
{
    class Grid
    {
        private int height;
        private int width;
        private Tile[,] tiles;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        //Base game init to remaster (adapt to settings)
        public void init(List<Team> teams)
        {
            this.tiles = new Tile[width,height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector2 v = new Vector2(x, y);
                    tiles[x,y] = new EmptyTile(v);
                }
            }
            tiles[2, 0] = new TempleTile(new Vector2(2,0), teams[1].getId());
            tiles[2, 4] = new TempleTile(new Vector2(2,4), teams[0].getId());

            foreach(Team t in teams){
                foreach (Piece p in t.getPieces())
                {
                    Vector2 v = p.getPosition();
                    tiles[v.x, v.y] = tiles[v.x, v.y].occupy(p);
                }
            }
           
        }

        public object transfer(Vector2 from, Vector2 to)
        {
            object o = new NullObject();
        
            Tile toTile = tiles[to.x, to.y];
            Tile fromTile = tiles[from.x, from.y];

            if (toTile.getState() == State.MOVINGTO)
            {
                o = toTile.onEnter(((OccupiedTile)fromTile).getPiece());
                tiles[to.x, to.y] = toTile.occupy(((OccupiedTile)fromTile).getPiece());
                tiles[from.x, from.y] = fromTile.onLeave();
            }

            return o;
        }

        public void selectTile(Vector2 v)
        {
            tiles[v.x, v.y].setState(State.SELECTED);
        }

        public void setMovingToTile(Vector2 v, int id)
        {
            try
            {
                if(tiles[v.x,v.y].GetType() == typeof(OccupiedTile))
                {
                    if(((OccupiedTile)tiles[v.x,v.y]).getPiece().getId() == id)
                    {
                        return;
                    } else if(tiles[v.x, v.y].GetType() == typeof(ObstacleTile))
                    {
                        return;
                    }
                }
                tiles[v.x, v.y].setState(State.MOVINGTO);
            } catch(IndexOutOfRangeException e)
            {

            }
        }

        public void unselectMovement()
        {
            foreach(Tile tile in tiles)
            {
                if (tile.getState() == State.MOVINGTO)
                {
                    tile.setState(State.UNSELECTED);
                }
            }
        }

        public void unselectAll()
        {
            foreach (Tile tile in tiles)
            {
                tile.setState(State.UNSELECTED);
            }
        }

        public void display()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if(tiles[x, y].GetType() == typeof(OccupiedTile))
                    {
                        switch(((OccupiedTile)tiles[x, y]).getPiece().getId())
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }
                    }
                    switch (tiles[x, y].getState()) {
                        case State.MOVINGTO:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case State.SELECTED:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                    tiles[x, y].display();
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
