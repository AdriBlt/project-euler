// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P009 : AbstractProblem
    {
        public override void DebugProblem()
        {
			DebugResult(FindPythagoreanTripletProductThatSums(12), 60);
        }

        public override long ComputeSolution()
        {
            return FindPythagoreanTripletProductThatSums(1000);
        }
		
        private long FindPythagoreanTripletProductThatSums(long sum)
        {
            for (int i = 1; i < sum; i++)
            {
                for (int j = i; j < sum; j++)
                {
                    long k = sum - i - j;
                    if (i * i + j * j == k * k)
                    {
                        return i * j * k;
                    }
                }
            }

            return -1;
        }
    }
}
