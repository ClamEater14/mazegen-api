using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenAPI.Generators
{
    internal class Cell
    {
        public CellWallFlag Walls { get; set; }
    }

    [Flags]
    internal enum CellWallFlag : byte
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
    }
}
