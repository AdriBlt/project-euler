// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P243: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(getSmallestDemWithResUnder(0.4), -1);
        }

        public override long ComputeSolution()
        {
			double borne = 15499.0 / 94744.0;
			return getSmallestDemWithResUnder(borne);
		}

		private static int getSmallestDemWithResUnder(double max) {
			for (int d = 2;; d++) {
				if (getResillience(d) < max) {
					return d;
				}
			}
		}

		private static double getResillience(int d) {
			int nombreRes = 1;
			for (int i = 2; i < d; i++) {
				if (Functions.GetGreatestCommonDivisor(i, d) == 1) {
					nombreRes++;
				}
			}

			return 1.0 * nombreRes / (d - 1);
		}
	}
}