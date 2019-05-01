using System;
using System.Collections.Generic;

namespace EscapeMines
{
    public class CommandManager
    {
        public static void ExecuteCommands(string command, Turtle turtle, List<Tile> board, ref bool comReady, ref string result, ref bool mineHit, ref bool success)
        {
            
            if (command == "") return;
            switch (command)
            {
                case "N":
                    turtle.SetDefaultDirection("N");
                    break;
                case "E":
                    turtle.SetDefaultDirection("E");
                    break;
                case "S":
                    turtle.SetDefaultDirection("S");
                    break;
                case "W":
                    turtle.SetDefaultDirection("W");
                    break;
                case "R":
                    turtle.RotateRight();
                    break;
                case "L":
                    turtle.RotateLeft();
                    break;
                case "M":
                    turtle.Move();
                    comReady = turtle.CheckMine(board);

                    if (comReady)
                    {
                        result = "Mine Hit!";
                        Console.WriteLine(result);
                        mineHit = true;
                    }
                    else
                    {
                        comReady = turtle.CheckExit(board);
                        if (comReady)
                        {
                            result = "Success!!";
                            Console.WriteLine(result);
                            success = true;
                        }
                    }
                    break;
                default:
                    result = $"Command = '{command}' was not used";
                    Console.WriteLine(result);
                    break;
            }


        }

        public static void SetStartingPoint(IReadOnlyList<string> startingPoint, Turtle turtle, List<Tile> board)
        {

            var foundStartingTile = board.Find(x => x.X == turtle.X && x.Y == turtle.Y);
            if (foundStartingTile != null)
            {
                foundStartingTile.IsStartingPoint = true;
                turtle.SetStartingPoint(int.Parse(startingPoint[0]), int.Parse(startingPoint[1]), startingPoint[2]);
            }
            else
            {
                Console.WriteLine("Tile with X = " + turtle.X + " and Y = " + turtle.Y + " is out of bounds");
            }
        }

        public static void SetExit(string[] exit, Turtle turtle, List<Tile> board)
        {
            var exitTile = new Tile
            {
                X = int.Parse(exit[0]),
                Y = int.Parse(exit[1])
            };
            var foundExitTile = board.Find(x => x.X == exitTile.X && x.Y == exitTile.Y);
            if (foundExitTile != null)
            {
                foundExitTile.IsExit = true;
                //turtle.SetExit(foundExitTile);
            }
            else
            {
                Console.WriteLine("Tile with X = " + exitTile.X + " and Y = " + exitTile.Y + " is out of bounds");
                
            }
        }

        public static void SetMines(IEnumerable<string> arrMines, Turtle turtle, List<Tile> board)
        {
            foreach (var mine in arrMines)
            {
                string[] minesCoordinates = mine.Split(",");
                var mineTile = new Tile
                {
                    X = int.Parse(minesCoordinates[0]),
                    Y = int.Parse(minesCoordinates[1])
                };

                var foundMineTile = board.Find(x => x.X == mineTile.X && x.Y == mineTile.Y);
                if (foundMineTile != null)
                {
                    foundMineTile.IsMine = true;
                }
                else
                {
                    Console.WriteLine("Mine with X = " + mineTile.X + " and Y = " + mineTile.Y + " is out of bounds");
                    break;
                }
            }
            //turtle.MinesSet(mines);
        }

        public static List<Tile> BuildBoard(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    tiles.Add(new Tile
                    {
                        X = i,
                        Y = j
                    });
                }
            }

            return tiles;
        }
    }
}