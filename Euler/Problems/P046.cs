// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P046: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			return getFirstOddUnder(100000);
		}

		private static long getFirstOddUnder(long borne) {
			List<long> primes = Functions.GetPrimesUnder(borne);
			for (long k = 3;; k += 2) {
				foreach (long p in primes) {
					if (p > k) {
						return k;
					}

					double root = Math.Sqrt(1.0 * (k - p) / 2);
					if (root % 1 == 0) {
						break;
					}
				}
			}
		}
	}
}
