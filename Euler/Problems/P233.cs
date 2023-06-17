// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P233: AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(getIntOnCircle(10000), -1);
        }

        public override long ComputeSolution()
        {
			long max = 100000000000L;
			long sum = 0;
			for (long n = 1; n < max; n++) {
				if (getIntOnCircle(n) == 420) {
					sum += n;
				}
			}

			return sum;
		}

		private static long getIntOnCircle(long circle) {
			long somme = 0;
			// long xInf = (long) Math.ceil(circle * (1 - Math.Sqrt(2)) / 2);
			// long xSup = (long) Math.floor(circle * (1 + Math.Sqrt(2)) / 2);
			// for (long x = xInf; x <= xSup; x++) {
			// if ((circle + Math.Sqrt(-4 * x * x + 4 * circle * x + circle
			// * circle)) / 2 % 1 == 0) {
			// somme++;
			// }
			// if ((circle - Math.Sqrt(-4 * x * x + 4 * circle * x + circle
			// * circle)) / 2 % 1 == 0) {
			// somme++;
			// }
			// if (somme > 420) {
			// return -1;
			// }
			long xMid = circle / 2;
			long xSup = (long) Math.Floor(circle * (1 + Math.Sqrt(2)) / 2);
			for (long x = xMid; x <= xSup; x++) {
				if ((circle + Math.Sqrt(-4 * x * x + 4 * circle * x + circle
						* circle)) / 2 % 1 == 0) {
					somme += 4;
				}

				if (somme > 420) {
					return -1;
				}
			}

			return somme;
		}
	}
}
