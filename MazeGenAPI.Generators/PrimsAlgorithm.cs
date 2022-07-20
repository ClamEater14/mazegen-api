namespace MazeGenAPI.Generators
{
    internal class PrimsAlgorithm : IAlgorithm
    {
        public char[][] GenerateMaze(uint width,
                                     uint height,
                                     char startSymbol,
                                     char endSymbol,
                                     char wallSymbol,
                                     char floorSymbol)
        {
            Random random = new();
            char[][] result = new char[height][];
            List<(int, int, int, int)> frontiers = new(); // (y0, x0, y1, x1): set of two consecutive points on a maze (inverted for array indexing)
            List<int> startYs = new();
            List<int> endYs = new();
            int x = random.Next(0, checked((int)width));
            int y = random.Next(0, checked((int)height));
            frontiers.Add((y, x, y, x));

            for (int i = 0; i < height; i++)
            {
                result[i] = new string(wallSymbol,
                                       checked((int)width)).ToCharArray();
            }

            while (frontiers.Count > 0)
            {
                int i = random.Next(frontiers.Count);
                var (y0, x0, y1, x1) = frontiers[i];
                frontiers.RemoveAt(i);

                x = x1;
                y = y1;

                if (result[y][x] == wallSymbol)
                {
                    result[y0][x0] = result[y][x] = floorSymbol;

                    if (x0 == 0)
                    {
                        startYs.Add(y0);
                    }

                    if (x0 == width - 1)
                    {
                        endYs.Add(y0);
                    }

                    if (x == 0)
                    {
                        startYs.Add(y);
                    }

                    if (x == width - 1)
                    {
                        endYs.Add(y);
                    }

                    if (x >= 2 && result[y][x - 2] == wallSymbol)
                    {
                        frontiers.Add((y, x - 1, y, x - 2));
                    }

                    if (y >= 2 && result[y - 2][x] == wallSymbol)
                    {
                        frontiers.Add((y - 1, x, y - 2, x));
                    }

                    if (x < width - 2 && result[y][x + 2] == wallSymbol)
                    {
                        frontiers.Add((y, x + 1, y, x + 2));
                    }

                    if (y < height - 2 && result[y + 2][x] == wallSymbol)
                    {
                        frontiers.Add((y + 1, x, y + 2, x));
                    }
                }
            }

            int startY = startYs.Count > 0 ? startYs[random.Next(0, startYs.Count)] : random.Next(0, checked((int)width));

            int endYIndex = 0;
            int endY = endYs.Count > 0 ? endYs[endYIndex = random.Next(0, endYs.Count)] : random.Next(0, checked((int)height));

            while (startY == endY)
            {
                if (endYs.Count > 0)
                {
                    endYs.RemoveAt(endYIndex);
                }

                endY = endYs.Count > 0 ? endYs[endYIndex = random.Next(0, endYs.Count)] : random.Next(0, checked((int)height));
            }

            result[startY][0] = startSymbol;
            result[endY][width - 1] = endSymbol;
            Algorithms.ClearStartAndEndWalls(result, checked((int)width), checked((int)height), startY, endY, wallSymbol, floorSymbol);

            return result;
        }
    }
}