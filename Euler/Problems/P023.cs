// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Collections.Generic;
using Euler.Utils;

namespace Euler.Problems
{
    using System;

    public class P023 : AbstractProblem
    {
        public override void DebugProblem()
        {
        }

        public override long ComputeSolution()
        {
            return GetResult();
        }

        private long GetResult()
        {
            int max = 28123;
            bool[] canBeWritten = new bool[max - 1];
            List<int> abundantNumbers = new List<int>();
            for (int i = 1; i < max; i++)
            {
                canBeWritten[i - 1] = false;
                if (i < Functions.GetDivisorsSum(i))
                {
                    abundantNumbers.Add(i);
                }
            }

            for (int i = 0; i < abundantNumbers.Count; i++)
            {
                for (int j = i; j < abundantNumbers.Count; j++)
                {
                    int number = abundantNumbers[i] + abundantNumbers[j];
                    if (number < max)
                    {
                        canBeWritten[number - 1] = true;
                    }
                }
            }

            long sum = 0;
            for (int i = 1; i < max; i++)
            {
                if (!canBeWritten[i - 1])
                {
                    sum += i;
                }
            }

            return sum;
        }

    }

}