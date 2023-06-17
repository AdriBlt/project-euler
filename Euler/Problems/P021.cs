// Copyright (c) Microsoft Corporation. All rights reserved.

using Euler.Utils;

namespace Euler.Problems
{
    using System;

    public class P021 : AbstractProblem
    {
        public override void DebugProblem()
        {
        }

        public override long ComputeSolution()
        {
            return GetAmicableNumbersSumBelow(1000);
        }
		
        public long GetAmicableNumbersSumBelow(int max)
        {
            long sum = 0;
            for (long i = 1; i <= 10000; i++)
            {
                long divisorsSum = Functions.GetDivisorsSum(i);
                if (divisorsSum <= i)
                {
                    continue;
                }

                long amicable = Functions.GetDivisorsSum(divisorsSum);
                if (i == amicable)
                {
                    sum += i + divisorsSum;
                }
            }

            return sum;
        }
    }

}