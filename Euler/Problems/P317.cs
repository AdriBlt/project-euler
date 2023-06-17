// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P317: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
            double g = 9.81;
            double h = 100;
            double v = 20;
            double volume = Math.PI * Math.Pow(v, 6) / Math.Pow(g, 3) * Math.Pow(1 + 2 * g * h / Math.Pow(v, 2), 2) / 4;

            return (long)volume;
        }
    }
}