// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P432: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			return getSommeTotient(510510, 6);
		}

		private static long getSommeTotient(long nombre, int exp) {
			VeryLong max = new VeryLong(nombre, exp);
			long maxRoot = max.GetRoot();
			List<long> primes = Functions.GetPrimesUnder(maxRoot);

			HashSet<long> divisors = new HashSet<long>();
			long root = (long) Math.Sqrt(nombre);
			foreach (long p in primes) {
				if (p > root) {
					break;
				}

				if (nombre % p == 0) {
					divisors.Add(p);
				}
			}

			IntegerMap totient = new IntegerMap(nombre);
			IntegerMap somme = new IntegerMap();
			VeryLong maxSomme = new VeryLong(1, exp);
			for (long i = 1; i <= maxSomme.GetNumber(); i++) {
				HashSet<long> iSet = new HashSet<long>(divisors);
				long iRoot = (long) Math.Sqrt(i);
				foreach (long p in primes) {
					if (p > iRoot) {
						if(p>i){
							break;
						} else {
							if(p==i) {
								iSet.Add(i);
							}
						}
					} else {
						if (i % p == 0) {
							iSet.Add(p);
						}
					}
				}

				IntegerMap iMap = new IntegerMap(totient);
				iMap.MultiplyBy(i);
				foreach (long p in iSet) {
					iMap.MultiplyBy(p-1);
					iMap.DivideBy((int) p);
				}

				somme.Add(iMap);
			}

			return somme.ToLong();
		}
	}
}
