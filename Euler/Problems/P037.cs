// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P037: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			List<long> primes = Functions.GetPrimesUnder(1000000);
			HashSet<long> trunc = new HashSet<long>();
			foreach (long p in primes) {
				if (p < 10) {
					continue;
				}

				int length = (int) Math.Floor(Math.Log10(p));
				bool isTrunc = true;
				int coef = 1;
				for (int i = 0; i < length; i++) {
					coef = coef * 10;
					long right = p / coef;
					long left = p % coef;
					if (!primes.Contains(right) || !primes.Contains(left)) {
						isTrunc = false;
						break;
					}
				}

				if(isTrunc){
					trunc.Add(p);
				}
			}

			long somme = 0;
			foreach (long p in trunc){
				Console.WriteLine(p);
				somme += p ;
			}

			Console.WriteLine(trunc.Count + " : " + somme);
			return somme;
		}
	}
}
