// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P050: AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(getLongestPrimesSumUnder(100), -1);
            DebugResult(getLongestPrimesSumUnder(1000), -1);
        }

        public override long ComputeSolution()
        {
			return getLongestPrimesSumUnder(1000000);
		}

		private static long getLongestPrimesSumUnder(long borne) {
			List<long> primes = Functions.GetPrimesUnder(borne);
			int size = primes.Count;
			long maxPrime = 0;
			int maxLength = 0;
			for (int i = 0; i < size; i++) {
				long somme = primes[i];
				for (int j = i + 1; j < size; j++) {
					somme += primes[j];
					if (somme > borne) {
						break;
					}

					int length = j - i + 1;
					if (length > maxLength) {
						if (Functions.IsPrime(somme)) {
							maxLength = length;
							maxPrime = somme;
						}
					}
				}
			}

			Console.WriteLine(maxPrime + " (" + maxLength + ")");
			return maxPrime;
		}
	}
}
