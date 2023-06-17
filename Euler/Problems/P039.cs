// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P039: AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(getNombrePythaPerimetre(120), -1);
        }

        public override long ComputeSolution()
        {
			long maxP = 0;
			long maxSol = 0;
			for (long p = 1; p <= 1000; p++) {
				long sol = getNombrePythaPerimetre(p);
				if (sol > maxSol) {
					maxSol = sol;
					maxP = p;
				}
			}

			Console.WriteLine(maxP + " (" + maxSol + ")");
			return maxP;
		}

		private static long getNombrePythaPerimetre(long p) {
			long sol = 0;
			for (long a = 1; a <= p; a++) {
				double b = 1.0 * p * (p - 2 * a) / (2 * (p - a));
				if(b < a || a + b > p){
					continue;
				}
				if (b % 1 == 0) {
					sol++;
				}
			}
			return sol;
		}
	}
}
