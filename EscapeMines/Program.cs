using System;
using System.Collections.Generic;
using System.IO;

namespace EscapeMines
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                Console.WriteLine("No file was selected, please select the settings file");
            }
            else
            {

                //var text = File.ReadLines(args.ToString());
                var text = File.ReadLines("test.txt");

                var linePos = 0;
                var board = new List<Tile>();
                var mines = new List<Tile>();
                var turtle = new Turtle();
                

                foreach (var line in text)
                {
                    switch (linePos)
                    {
                        case 0:
                            Console.WriteLine("Board settings = " + line);
                            var coordinatesSplit = line.Split(" ");
                            board = CommandManager.BuildBoard(int.Parse(coordinatesSplit[0]), int.Parse(coordinatesSplit[1]));

                            break;
                        case 1:
                            Console.WriteLine("List of mines = " + line);
                            var minesSplit = line.Split(" ");
                            CommandManager.SetMines(minesSplit, turtle, board);

                            break;
                        case 2:
                            Console.WriteLine("Exit Point = " + line);
                            var exitSplit = line.Split(" ");
                            CommandManager.SetExit(exitSplit, turtle, board);

                            break;
                        case 3:
                            Console.WriteLine("Starting Point = " + line);
                            var startingPointSplit = line.Split(" ");
                            CommandManager.SetStartingPoint(startingPointSplit, turtle, board);

                            break;
                        default:

                            Console.WriteLine("Moves = " + line);
                            var comSequenceSplit = line.Split(" ");
                            var comReady = false;
                            var comSequenceCount = 0;
                            var success = false;
                            var mineHit = false;
                            var result = "";

                            while (!comReady)
                            {
                                foreach (var command in comSequenceSplit)
                                {
                                    comSequenceCount++;
                                    CommandManager.ExecuteCommands(command, turtle, board, ref comReady, ref result, ref mineHit, ref success);
                                    if (!comReady) continue;
                                    turtle.ResetPosition();
                                    break;
                                }

                                if (comSequenceCount != comSequenceSplit.Length || (success || mineHit)) continue;
                                result = "Still in Danger!";
                                Console.WriteLine(result);
                                turtle.ResetPosition();
                                break;
                            }
                            break;
                    }
                    linePos++;
                }

            }
            Console.ReadLine();
        }
    }
}
