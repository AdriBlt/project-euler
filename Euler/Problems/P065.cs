// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Numbers;

    public class P065: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			for (int i = 1; i <= 100; i++) {
				Console.WriteLine(i + " " + getExponentielFrac(i));
			}
			//
			//		int nombre = 100;
			//		Fraction frac = getExponentielFrac(nombre);
			//		frac.simplify();
			//		int num = frac.getNumerateur();
			//		int somme = 0;
			//		while (num > 0) {
			//			somme += num % 10;
			//			num = num / 10;
			//		}
			//		Console.WriteLine(somme);
			return -1;
		}

		private static Fraction getExponentielFrac(int k) {
			Fraction nombre = new Fraction(getExponentielFracCoef(k));
			for (int j = k-1; j > 0; j--) {
				nombre = nombre.Invert().Add(new Fraction(getExponentielFracCoef(j)));
			}
			return nombre;
		}

		private static int getExponentielFracCoef(int j) {
			if (j == 1) {
				return 2;
			}

			if (j % 3 == 0) {
				return 2 * j / 3;
			}

			return 1;
		}
	}
}
