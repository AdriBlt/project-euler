// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System.Collections.Generic;

    public class P014 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetChainLength(13, new Dictionary<long, long> { [1] = 1 }), 10);
        }

        public override long ComputeSolution()
        {
            return GetLongestChainUnder(1000000);
        }
		
        private long GetLongestChainUnder(long max)
        {
            long maxValue = 1;
            long maxKey = 1;
            Dictionary<long, long> lengths = new Dictionary<long, long> { [1] = 1 };
            for (long i = 2; i < max; i++)
            {
                long length = GetChainLength(i, lengths);
                if (length > maxValue)
                {
                    maxValue = length;
                    maxKey = i;
                }
            }

            return maxKey;
        }

        private long GetChainLength(long number, Dictionary<long, long> lengths)
        {
            long length = 0;
            long currentNumber = number;
            while (!lengths.ContainsKey(currentNumber))
            {
                if (currentNumber % 2 == 0)
                {
                    currentNumber = currentNumber / 2;
                    length += 1;
                }
                else
                {
                    currentNumber = (3 * currentNumber + 1) / 2;
                    length += 2;
                }
            }

            length += lengths[currentNumber];
            lengths[number] = length;
            return length;
        }

    }
}