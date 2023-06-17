// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System.Collections.Generic;
    using Euler.Utils;

    public class P041: AbstractProblem
    {

        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			return primesMethod(7654321L);
		}

		private static long primesMethod(long borne) {
			List<long> primes = Functions.GetPrimesUnder(borne);
			int size = primes.Count;
			for (int i = size - 1; i > 0; i--) {
				long prime = primes[i];
				if (Functions.IsPandigitalStrict(prime)) {
					return prime;
				}
			}

			return 0;
		}
	}
}
