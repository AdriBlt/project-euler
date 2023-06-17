// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P006 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetSquareDiff(10), 2640);
        }

        public override long ComputeSolution()
        {
            return GetSquareDiff(100);
        }

        private static long GetSquareDiff(int max)
        {
            long sum = 0;
            for (int i = 1; i < max; i++)
            {
                for (int j = i + 1; j <= max; j++)
                {
                    sum += 2 * i * j;
                }
            }
            return sum;
        }
    }
}