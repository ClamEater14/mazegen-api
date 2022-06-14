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
        Kruskal,
        DepthFirstSearch,
    }

    public static class Algorithms
    {
        public static IAlgorithm GetAlgorithm(Algorithm algorithmType)
        {
            return algorithmType switch
            {
                Algorithm.Prim => new PrimsAlgorithm(),
                Algorithm.Kruskal => new KruskalsAlgorithm(),
                Algorithm.DepthFirstSearch => new DFSAlgorithm(),
                _ => throw new ArgumentException("algorithm not found!"),
            };
        }
    }
}
