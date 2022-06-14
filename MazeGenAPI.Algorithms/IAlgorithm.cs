using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenAPI.Generators
{
    public interface IAlgorithm
    {
        public abstract char[][] GenerateMaze(uint width, uint height, char startSymbol, char endSymbol, char wallSymbol, char floorSymbol);
    }
}
