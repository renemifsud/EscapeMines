using System.Collections.Generic;
using NUnit.Framework;

namespace EscapeMines.UnitTests
{
    public class ExecuteCommandsTest
    {
        [Test]
        public void ExecuteCommands_UnknownCommand_ResultCommandNotUsed()
        {
            var turtle = new Turtle{X = 0, Y = 0};
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("V"), turtle, new List<Tile>(), ref comReady, ref result, ref mineHit, ref success);

            Assert.True(result.Contains("was not used"));
            Assert.True(turtle.X ==0 && turtle.Y ==0);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_NCommand_TurtleDirectionSet1()
        {
            var turtle = new Turtle { X = 0, Y = 0, TurtleDirection = 0 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("N"), turtle, new List<Tile>(), ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 0 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 1);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_ECommand_TurtleDirectionSet2()
        {
            var turtle = new Turtle { X = 0, Y = 0, TurtleDirection = 0 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("E"), turtle, new List<Tile>(), ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 0 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 2);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_SCommand_TurtleDirectionSet3()
        {
            var turtle = new Turtle { X = 0, Y = 0, TurtleDirection = 0 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("S"), turtle, new List<Tile>(), ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 0 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 3);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_WCommand_TurtleDirectionSet4()
        {
            var turtle = new Turtle { X = 0, Y = 0, TurtleDirection = 0 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("W"), turtle, new List<Tile>(),  ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 0 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 4);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_MCommand_TurtleDirection1_YDecreased()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 1 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;
            var board = CommandManager.BuildBoard(4, 4);
            board[15].IsExit = true;

            CommandManager.ExecuteCommands(new string("M"), turtle, board, ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 1 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 1);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_MCommand_TurtleDirection2_XIncreased()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 2 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;
            var board = CommandManager.BuildBoard(4, 4);
            board[15].IsExit = true;

            CommandManager.ExecuteCommands(new string("M"), turtle, board, ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 2 && turtle.Y == 1);
            Assert.True(turtle.TurtleDirection == 2);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_MCommand_TurtleDirection3_YIncreased()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 3 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;
            var board = CommandManager.BuildBoard(4, 4);
            board[15].IsExit = true;

            CommandManager.ExecuteCommands(new string("M"), turtle, board, ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 1 && turtle.Y == 2);
            Assert.True(turtle.TurtleDirection == 3);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_MCommand_TurtleDirection4_XDecreased()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 4 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;
            var board = CommandManager.BuildBoard(4, 4);
            board[15].IsExit = true;

            CommandManager.ExecuteCommands(new string("M"), turtle, board, ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 0 && turtle.Y == 1);
            Assert.True(turtle.TurtleDirection == 4);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_MCommand_MoveToExitResultSuccess()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 1 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;
            var board = CommandManager.BuildBoard(4,4);
            CommandManager.SetExit(new []{"1","0"}, turtle, board);

            CommandManager.ExecuteCommands(new string("M"), turtle, board, ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.True(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 1 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 1);
            Assert.True(comReady);
            Assert.True(success);
            Assert.False(mineHit);

        }

        [Test]
        public void ExecuteCommands_MCommand_MoveToMineResultMineHit()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 1 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;
            var board = CommandManager.BuildBoard(4, 4);
            board[15].IsExit = true;
            CommandManager.SetMines(new[] { "1,0", "0,1" }, turtle, board);

            CommandManager.ExecuteCommands(new string("M"), turtle, board, ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.True(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 1 && turtle.Y == 0);
            Assert.True(turtle.TurtleDirection == 1);
            Assert.True(comReady);
            Assert.False(success);
            Assert.True(mineHit);

        }

        [Test]
        public void ExecuteCommands_LCommand_TurtleDirectionDecreased()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 4 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("L"), turtle, new List<Tile>(),  ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 1 && turtle.Y == 1);
            Assert.True(turtle.TurtleDirection == 3);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

        [Test]
        public void ExecuteCommands_RCommand_TurtleDirectionIncreased()
        {
            var turtle = new Turtle { X = 1, Y = 1, TurtleDirection = 4 };
            var comReady = false;
            var result = "";
            var mineHit = false;
            var success = false;

            CommandManager.ExecuteCommands(new string("R"), turtle, new List<Tile>(),  ref comReady, ref result, ref mineHit, ref success);

            Assert.False(result.Contains("not used"));
            Assert.False(result.Contains("Success"));
            Assert.False(result.Contains("Still in Danger"));
            Assert.False(result.Contains("Mine Hit!"));
            Assert.True(turtle.X == 1 && turtle.Y == 1);
            Assert.True(turtle.TurtleDirection == 1);
            Assert.False(comReady);
            Assert.False(mineHit);
            Assert.False(success);
        }

    }
    
    
    public class SetStartingPointTest
    {
        public void SetStartingPoint_PointInRange_ReturnTrue()
        {
            var turtle = new Turtle();
            var board = CommandManager.BuildBoard(5,5);

            CommandManager.SetStartingPoint(new []{"1","1"}, turtle,board);

            //Assert.True(turtle.);
        }
        
    }

    public class SetExit { }

    public class SetMines { }

    public class BuildBoard { }
}