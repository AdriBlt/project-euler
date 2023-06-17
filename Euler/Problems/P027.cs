// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P027: AbstractProblem
    {

        public override void DebugProblem()
        {
			DebugResult(getNumberOfPrime(1, 41), -1);
			DebugResult(getNumberOfPrime(-79, 1601), -1);
        }

        public override long ComputeSolution()
        {
			return getMaxNumberOfPrime(999);
		}

		private static long getMaxNumberOfPrime(long borne) {
			long bestProd = 0;
			long bestVal = 0;
			for (long b = 2; b <= borne; b++) {
				if (!b.IsPrime()) {
					continue;
				}
				for (long a = -borne; a <= borne; a++) {
					long num = getNumberOfPrime(a, b);
					if (num > bestVal) {
						bestProd = a * b;
						bestVal = num;
					}
				}
			}
			return bestProd;
		}

		private static long getNumberOfPrime(long a, long b) {
			long nombre = b;
			for (long i = 0;; i++) {
				if (nombre.IsPrime()) {
					nombre += 2 * i + a + 1;
				} else {
					return i;
				}
			}
		}
	}
}