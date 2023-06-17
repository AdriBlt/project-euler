// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class P007 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetNthPrime(6), 13);
        }

        public override long ComputeSolution()
        {
            return GetNthPrime(10001);
        }

        private long GetNthPrime(int index)
        {
            List<long> primes = new List<long>();
            for (long i = 2; primes.Count < index; i++)
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
                }
            }

            return primes.Last();
        }
    }
}
