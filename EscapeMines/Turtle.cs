using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    public class Turtle : Tile
    {
        private readonly Tile _startingPoint = new Tile();

        public int TurtleDirection;
        public int TurtleDefaultDirection;
        private bool _isResetDirectionSet = false;

        public void SetDefaultDirection(string _command)
        {
            switch (_command)
            {
                case "N":
                    TurtleDirection = 1;
                    if (!_isResetDirectionSet)
                        TurtleDefaultDirection = TurtleDirection;
                    break;
                case "E":
                    TurtleDirection = 2;
                    if (!_isResetDirectionSet)
                        TurtleDefaultDirection = TurtleDirection;
                    break;
                case "S":
                    TurtleDirection = 3;
                    if (!_isResetDirectionSet)
                        TurtleDefaultDirection = TurtleDirection;
                    break;
                case "W":
                    TurtleDirection = 4;
                    if (!_isResetDirectionSet)
                        TurtleDefaultDirection = TurtleDirection;
                    break;

            }
        }

       
        public void Move()
        {
            switch (TurtleDirection)
            {
              case 1:
                    Y--;
                    break;
                case 2:
                    X++;
                    break;
                case 3:
                    Y++;
                    break;
                case 4:
                    X--;
                    break;
                
            }
        }

        public void RotateRight()
        {
            TurtleDirection++;
            if (TurtleDirection == 5)
                TurtleDirection = 1;
        }

        public void RotateLeft()
        {
            TurtleDirection--;
            if(TurtleDirection == 0)
                TurtleDirection = 4;
        }

        public void MinesSet(List<Tile> _mines)
        {
        }

        public void SetExit(Tile _exit)
        {
        }

        public bool CheckMine(List<Tile> board)
        {
            var mines = board.FindAll(x => x.IsMine);
            foreach (var mine in mines)
            {
                if(mine.X == X && mine.Y == Y)
                return true;
            }
            return false;
        }

        public bool CheckExit(List<Tile> board)
        {
            var exit = board.Find(x => x.IsExit);
            return exit.X == X && exit.Y == Y;
        }

        public void SetStartingPoint(int x, int y, string direction)
        {
            X = x;
            Y = y;
            SetDefaultDirection(direction);

            _startingPoint.X = x;
            _startingPoint.Y = y;
            SetDefaultDirection(direction);
        }

        public void ResetPosition()
        {
            X = _startingPoint.X;
            Y = _startingPoint.Y;
            TurtleDirection = TurtleDefaultDirection;
        }
    }
}
