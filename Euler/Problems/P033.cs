// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Numbers;

    public class P033: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			Fraction frac = new Fraction(1);
			for (int i = 1; i < 10; i++) {
				for (int j = i + 1; j < 10; j++) {
					for (int k = 0; k < 10; k++) {
						if ((10.0 * i + k) * j == (10.0 * k + j) * i) {
							frac = Fraction.Multiply(frac, new Fraction(i, j));
						}
						if ((10.0 * k + i) * j == (10.0 * j + k) * i) {
							frac = Fraction.Multiply(frac, new Fraction(i, j));
						}
						if (k > 0) {
							if ((10.0 * k + i) * j == (10.0 * k + j) * i) {
								frac = Fraction.Multiply(frac, new Fraction(i, j));
							}
							if ((10.0 * i + k) * j == (10.0 * j + k) * i) {
								frac = Fraction.Multiply(frac, new Fraction(i, j));
							}
						}
					}
				}
			}

			frac.Simplify();
			return frac.GetDenominator();
		}
	}
}
