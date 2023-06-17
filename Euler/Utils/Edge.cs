// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;

    public class Edge : IComparable<Edge>
    {
		private readonly int _verticleA;

        private readonly int _verticleB;

        private readonly int _weight;

        public Edge(int a, int b, int w)
        {
            this._verticleA = a;
            this._verticleB = b;
            this._weight = w;
        }

        /** @return the verticleA */
        public int GetA()
        {
            return this._verticleA;
        }

        /** @return the verticleB */
        public int GetB()
        {
            return this._verticleB;
        }

        /** @return the verticleA */
        public int GetWeight()
        {
            return this._weight;
        }
		
        public int CompareTo(Edge other)
        {
            if (this._weight < other._weight)
            {
                return -1;
            }

            if (this._weight > other._weight)
            {
                return 1;
            }

            return 0;
        }
    }
}