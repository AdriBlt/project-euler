// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P049: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			int pas = 3330;
			List<long> primes = Functions.GetPrimesUnder(9999);
			foreach (long p in primes) {
				if (p < 1000) {
					continue;
				}

				long pp = p + pas;
				long ppp = pp + pas;

				if (hasSameDigits(p, pp, ppp)) {
					if (Functions.IsPrime(pp) && Functions.IsPrime(ppp)) {
						string str = p.ToString() + pp.ToString() + ppp.ToString();
						Console.WriteLine(str);
						return p;
					}
				}
			}

			return -1;
		}

		private static bool hasSameDigits(long p, long pp, long ppp) {
			char[] setP = p.ToString().ToCharArray();
			char[] setPP = pp.ToString().ToCharArray();
			char[] setPPP = ppp.ToString().ToCharArray();
			int size = setP.Length;
			if (setPP.Length != size || setPPP.Length != size) {
				return false;
			}

			for (int i = 0; i < size; i++) {
				char c = setP[i];
				bool boolPP = false;
				bool boolPPP = false;
				for (int j = 0; j < size; j++) {
					if (setPP[j] == c) {
						boolPP = true;
					}

					if (setPPP[j] == c) {
						boolPPP = true;
					}
				}

				if (!boolPP || !boolPPP) {
					return false;
				}
			}

			return true;
		}
	}
}
