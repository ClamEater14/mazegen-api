using MazeGenAPI.Generators;

namespace MazeGenAPI.Models
{
    public class Maze
    {
        public IEnumerable<string> Contents { get; }
        public uint Width { get; }
        public uint Height { get; }
        public Algorithm Algorithm { get; }
        public char StartSymbol { get; }
        public char EndSymbol { get; }
        public char WallSymbol { get; }
        public char FloorSymbol { get; }

        public Maze(uint width,
                    uint height,
                    Algorithm algorithm,
                    char startSymbol,
                    char endSymbol,
                    char wallSymbol,
                    char floorSymbol)
        {
            Width = width;
            Height = height;
            Algorithm = algorithm;
            StartSymbol = startSymbol;
            EndSymbol = endSymbol;
            WallSymbol = wallSymbol;
            FloorSymbol = floorSymbol;
            Contents = Algorithms.GetAlgorithm(algorithm)
                                 .GenerateMaze(width,
                                               height,
                                               startSymbol,
                                               endSymbol,
                                               wallSymbol,
                                               floorSymbol)
                                 .Select(row => new string(row));
        }
    }
}
