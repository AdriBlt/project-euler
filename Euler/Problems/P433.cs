// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P433: AbstractProblem
    {
        public override void DebugProblem()
        {
			Console.WriteLine(getSommeEulerStep(1));
			Console.WriteLine(new EulerSum(1).GetSommeEulerStep());
			Console.WriteLine(getSommeEulerStep(10));
			Console.WriteLine(new EulerSum(10).GetSommeEulerStep());
			Console.WriteLine(getSommeEulerStep(100));
			Console.WriteLine(new EulerSum(100).GetSommeEulerStep());
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			new EulerSum(5000000).GetSommeEulerStepBySteps();
			return -1;
		}

		private static string getSommeEulerStep(long n) {
			IntegerMap dictionary = new IntegerMap();
			for (long x = 1; x <= n; x++) {
				for (long y = 1; y <= n; y++) {
					dictionary.Add(getNumberEulerStep(x, y));
				}
			}

			return dictionary.ToString();
		}

		private static long getNumberEulerStep(long x0, long y0) {
			long n = 0;
			long x = x0;
			long y = y0;
			while (y > 0) {
				n++;
				long z = y;
				y = x % z;
				x = z;
			}

			return n;
		}
	}
}
