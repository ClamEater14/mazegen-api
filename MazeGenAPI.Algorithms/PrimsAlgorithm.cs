﻿namespace MazeGenAPI.Generators
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
            char[][] result = new char[height][];
            HashSet<(int, int)> walls = new();
            for (int i = 0; i < height; i++)
            {
                result[i] = new string(floorSymbol,
                                       checked((int)width)).ToCharArray();

                for (int j = 0; j < width; j++)
                {
                    //result[i][j] = ((i + j) % 2 == 0 && i % 2 == 0) ? floorSymbol : wallSymbol;
                    if ((i + j) % 2 == 0 && i % 2 == 0)
                    {
                        result[i][j] = floorSymbol;
                    } else
                    {
                        result[i][j] = wallSymbol;
                        walls.Add((i, j));
                    }
                }

            }

            return result;
        }
    }
}