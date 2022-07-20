using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenAPI.Generators
{
    public enum Algorithm
    {
        Prim,
        DepthFirstSearch,
    }

    public static class Algorithms
    {
        public static IAlgorithm GetAlgorithm(Algorithm algorithmType)
        {
            return algorithmType switch
            {
                Algorithm.Prim => new PrimsAlgorithm(),
                Algorithm.DepthFirstSearch => new DFSAlgorithm(),
                _ => throw new ArgumentException("algorithm not found!"),
            };
        }

        internal static void ClearStartAndEndWalls(char[][] maze,
                                           int width,
                                           int height,
                                           int startY,
                                           int endY,
                                           char wallSymbol,
                                           char floorSymbol)
        {
            Random random = new();
            List<(int, int)> wallsToClear = new(3); // positions of walls around start (then end) for potential clearing
            bool shouldClear = true;

            if (maze[startY][1] == wallSymbol)
            {
                wallsToClear.Add((startY, 1));
            }
            else
            {
                shouldClear = false;
            }

            if (startY > 0)
            {
                if (maze[startY - 1][0] == wallSymbol)
                {
                    wallsToClear.Add((startY - 1, 0));
                }
                else
                {
                    shouldClear = false;
                }
            }

            if (startY < height - 1)
            {
                if (startY < height - 1 && maze[startY + 1][0] == wallSymbol)
                {
                    wallsToClear.Add((startY + 1, 0));
                }
                else
                {
                    shouldClear = false;
                }
            }

            // Destroy a wall surrounding start
            if (shouldClear)
            {
                var (toClearRow, toClearCol) = wallsToClear[random.Next(0, wallsToClear.Count)];
                maze[toClearRow][toClearCol] = floorSymbol;
            }

            wallsToClear.Clear();
            shouldClear = true;

            if (maze[endY][width - 2] == wallSymbol)
            {
                wallsToClear.Add((endY, width - 2));
            }
            else
            {
                shouldClear = false;
            }

            if (endY > 0)
            {
                if (maze[endY - 1][width - 1] == wallSymbol)
                {
                    wallsToClear.Add((endY - 1, width - 1));
                }
                else
                {
                    shouldClear = false;
                }
            }

            if (endY < height - 1)
            {
                if (maze[endY + 1][width - 1] == wallSymbol)
                {
                    wallsToClear.Add((endY + 1, width - 1));
                }
                else
                {
                    shouldClear = false;
                }
            }

            // Destroy a wall surrounding end
            if (shouldClear)
            {
                var (toClearRow, toClearCol) = wallsToClear[random.Next(0, wallsToClear.Count)];
                maze[toClearRow][toClearCol] = floorSymbol;
            }
        }
    }
}
