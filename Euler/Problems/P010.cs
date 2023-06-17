// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;

    public class P010 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetSumOfPrimesBelow(10), 17);
        }

        public override long ComputeSolution()
        {
            return GetSumOfPrimesBelow(2000000);
        }
		
        private long GetSumOfPrimesBelow(long max)
        {
            long sum = 0;
            List<long> primes = new List<long>();
            for (long i = 2; i < max; i++)
            {
                bool isPrime = true;
                double root = Math.Sqrt(i);
                foreach (long prime in primes)
                {
                    if (prime > root)
                    {
                        break;
                    }

                    if (i % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                    sum += i;
                }
            }

            return sum;
        }

    }
}