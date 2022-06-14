namespace MazeGenAPI.Generators
{
    internal class DFSAlgorithm : IAlgorithm
    {
        public char[][] GenerateMaze(uint width, uint height, char startSymbol, char endSymbol, char wallSymbol, char floorSymbol)
        {
            Random random = new Random();
            char[][] result = new char[height][];
            bool[,] seen = new bool[height, width];
            (int, int)[,] previous = new (int, int)[height, width];
            Stack<(int, int)> stack = new Stack<(int, int)>();

            (int, int) start = (random.Next(0, checked((int)height)), 0);
            (int, int) end = (random.Next(0, checked((int)height)), checked((int)width) - 1);

            // Initialize maze and auxiliary data
            for (int i = 0; i < height; i++)
            {
                // Start with all walls
                result[i] = new string(wallSymbol,
                                       checked((int)width)).ToCharArray();

                // All seen values should be false, and previous values should be (-1, -1)
                for (int j = 0; j < width; j++)
                {
                    seen[i, j] = false;
                    previous[i, j] = (-1, -1);
                }
            }

            // Initialize the stack with the start
            stack.Push(start);

            while (stack.Count > 0)
            {
                // Take the next position to cover
                var (x, y) = stack.Pop();
                seen[x, y] = true;

                // Check if cycles will occur:
                // If adjacent position is in the maze (not out of bounds),
                // the current position is not already a floor, and
                // the previous position on the path is not this position,
                // a cycle will occur
                if (x + 1 < height && result[x + 1][y] == floorSymbol && previous[x, y] != (x + 1, y))
                {
                    continue;
                }

                if (x > 0 && result[x - 1][y] == floorSymbol && previous[x, y] != (x - 1, y))
                {
                    continue;
                }

                if (y + 1 < width && result[x][y + 1] == floorSymbol && previous[x, y] != (x, y + 1))
                {
                    continue;
                }

                if (y > 0 && result[x][y - 1] == floorSymbol && previous[x, y] != (x, y - 1))
                {
                    continue;
                }

                // Mark as floor
                result[x][y] = floorSymbol;

                // list of positions to add to the stack
                List<(int, int)> toStack = new List<(int, int)>(4);

                if (x + 1 < height && !seen[x + 1, y])
                {
                    // Mark the adj position as seen
                    seen[x + 1, y] = true;

                    // Add the adj position to the stack later
                    toStack.Add((x + 1, y));

                    // Mark the adj position's previous spot on the path
                    // to this position
                    previous[x + 1, y] = (x, y);
                }

                if (x > 0 && !seen[x - 1, y])
                {
                    // Mark the adj position as seen
                    seen[x - 1, y] = true;

                    // Add the adj position to the stack later
                    toStack.Add((x - 1, y));

                    // Mark the adj position's previous spot on the path
                    // to this position
                    previous[x - 1, y] = (x, y);
                }

                if (y + 1 < width && !seen[x, y + 1])
                {
                    // Mark the adj position as seen
                    seen[x, y + 1] = true;

                    // Add the adj position to the stack later
                    toStack.Add((x, y + 1));

                    // Mark the adj position's previous spot on the path
                    // to this position
                    previous[x, y + 1] = (x, y);
                }

                if (y > 0 && !seen[x, y - 1])
                {
                    // Mark the adj position as seen
                    seen[x, y - 1] = true;

                    // Add the adj position to the stack later
                    toStack.Add((x, y - 1));

                    // Mark the adj position's previous spot on the path
                    // to this position
                    previous[x, y - 1] = (x, y);
                }

                // A flag to indicate the finish is one of the added positions
                bool hasEndPos = false;

                while (toStack.Count > 0)
                {
                    // Take a random position from the upcoming ones
                    // to add to the stack
                    int randIndex = random.Next(0, toStack.Count);
                    var neighbor = toStack[randIndex];
                    toStack.RemoveAt(randIndex);

                    // If the chosen neighbor turns out to be the end position
                    if (neighbor == end)
                    {
                        // Add it later, we mark it for now
                        hasEndPos = true;
                    }
                    else
                    {
                        // Otherwise, add the position to the stack now
                        stack.Push(neighbor);
                    }
                }

                // If the end position has to be added, add it here
                // The end position will be at the top in this case
                if (hasEndPos)
                {
                    stack.Push(end);
                }
            }

            // Mark the start and end
            result[start.Item1][start.Item2] = startSymbol;
            result[end.Item1][end.Item2] = endSymbol;

            // We are done!
            return result;
        }
    }
}
