// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;
    using System.Collections.Generic;

    public class Kruskal
    {
        private int _size;

        private int _totalWeight;

        private List<Edge> _edges;

        private HashSet<Edge> _tree;

        private int _treeWeight;

        public Kruskal(string[][] network)
        {
            _size = network.Length;
            _totalWeight = 0;
            _edges = new List<Edge>();

            // Build Graph
            for (int i = 0; i < _size; i++)
            {
                int sSize = network[i].Length;
                if (sSize != _size)
                {
                    throw new ArgumentException($"Line {i} is of size {sSize} instead of {_size}");
                }

                for (int j = 0; j < i; j++)
                {
                    try
                    {
                        int val = int.Parse(network[i][j]);
                        _edges.Add(new Edge(j, i, val));
                        _totalWeight += val;
                    }
                    catch (FormatException)
                    {
                    }
                }
            }
        }

        public void Run()
        {

            _tree = new HashSet<Edge>();
            _treeWeight = 0;

            // Build Tree
            Dictionary<int, int> kruskalMap = new Dictionary<int, int>();
            for (int i = 0; i < _size; i++)
            {
                kruskalMap[i] =  i;
            }

			_edges.Sort();

            foreach (Edge edge in _edges)
            {
                int kruskalA = kruskalMap[edge.GetA()];
                int kruskalB = kruskalMap[edge.GetB()];
                if (kruskalA == kruskalB)
                {
                    continue;
                }

                _tree.Add(edge);
                _treeWeight += edge.GetWeight();
                int min = Math.Min(kruskalA, kruskalB);
                int max = Math.Max(kruskalA, kruskalB);
                for (int i = 0; i < _size; i++)
                {
                    if (kruskalMap[i] == max)
                    {
                        kruskalMap[i] = min;
                    }
                }
            }
        }

        public int GetSavings()
        {
            return _totalWeight - _treeWeight;
        }

    }

}