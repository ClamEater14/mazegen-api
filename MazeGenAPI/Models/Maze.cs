using MazeGenAPI.Generators;

namespace MazeGenAPI.Models
{
    public class Maze
    {
        public IEnumerable<string> Contents { get; }
        public uint NumRoomsX { get; }
        public uint NumRoomsY { get; }
        public Algorithm Algorithm { get; }
        public char StartSymbol { get; }
        public char EndSymbol { get; }
        public char WallSymbol { get; }
        public char FloorSymbol { get; }

        public Maze(uint corridorsX,
                    uint corridorsY,
                    Algorithm algorithm,
                    char startSymbol,
                    char endSymbol,
                    char wallSymbol,
                    char floorSymbol)
        {
            NumRoomsX = corridorsX;
            NumRoomsY = corridorsY;
            Algorithm = algorithm;
            StartSymbol = startSymbol;
            EndSymbol = endSymbol;
            WallSymbol = wallSymbol;
            FloorSymbol = floorSymbol;
            Contents = Algorithms.GetAlgorithm(algorithm)
                                 .GenerateMaze(2 * corridorsX + 1,
                                               2 * corridorsY + 1,
                                               startSymbol,
                                               endSymbol,
                                               wallSymbol,
                                               floorSymbol)
                                 .Select(row => new string(row));
        }
    }
}
