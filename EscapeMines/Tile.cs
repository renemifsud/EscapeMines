using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsMine { get; set; }
        public bool IsExit { get; set; }
        public bool IsStartingPoint { get; set; }

    }
}
