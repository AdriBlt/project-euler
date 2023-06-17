// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P047: AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(getTripletWithDistinctPrimeDivisors(2, 100000), -1);
            DebugResult(getTripletWithDistinctPrimeDivisors(3, 100000), -1);
        }

        public override long ComputeSolution()
        {
			return getTripletWithDistinctPrimeDivisors(4, 100000);
		}

		private static long getTripletWithDistinctPrimeDivisors(int nombre, long borne) {
			List<long> primes = Functions.GetPrimesUnder(borne);
			long n = 1;
			while (true) {
				for (int i = 0; i <= nombre; i++) {
					if (i == nombre) {
						return n;
					}
					
					int nb = Functions.GetPrimeDivisorCount(n + i, primes);
					if (nb != nombre) {
						n += 1 + i;
						break;
					}
				}
			}
		}
	}
}
