// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P144: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			Coord c0 = new Coord(0.0, 10.1);
			Coord c1 = new Coord(1.4, -9.6);
			Console.WriteLine("0 : " + c0);
			Console.WriteLine("1 : " + c1);

			Coord c = c0;
			Coord cc = c1;

			int count = 1;
			while (true) {
				Coord next = getNextPoint(c, cc);
				c = cc;
				cc = next;
				Console.WriteLine(count + " : " + cc);
				if (Math.Abs(cc.X) <= 0.01 && cc.Y > 0) {
					Console.WriteLine(count);
					break;
				}

				count++;
			}

			return count;
		}

		private static Coord getNextPoint(Coord c0, Coord c1) {
			if (c1.X == c0.X) {
				Console.WriteLine("Erreur 1 : X0 = X1");
			}

			double coefDroite = (c1.Y - c0.Y) / (c1.X - c0.X);
			if (c1.Y == 0) {
				Console.WriteLine("Erreur 2 : Y1 = 0");
			}

			double coefTangente = -4 * c1.X / c1.Y;

			// double coefNum = 2 * coefTangente + coefDroite * (Math.Pow(coefTangente, 2) - 1);
			double coefDenum = 1 + coefTangente * (2 * coefDroite - coefTangente);

			if (coefDenum == 0) {
				Console.WriteLine("Erreur 3 : M[n+1] = inf");
			}

			double coef = (-8 * c1.X * c1.Y * (c1.X - c0.X) + (c1.Y - c0.Y) * (16 * Math.Pow(c1.X, 2) - Math.Pow(c1.Y, 2)))
					/ (Math.Pow(c1.Y, 2) * (c1.X - c0.X) - 8 * c1.X * (c1.Y * (c1.Y - c0.Y) + 2 * (c1.X - c0.X) * c1.X));

			double p = c1.Y - c1.X * coef;
			double delta = 400 * Math.Pow(coef, 2) - 16 * Math.Pow(p, 2) + 1600;
			if (delta <= 0) {
				Console.WriteLine("Erreur 4 : Delta <= 0");
			}

			double xp = (-2 * coef * p + Math.Sqrt(delta)) / (8 + 2 * Math.Pow(coef, 2));
			double xm = (-2 * coef * p - Math.Sqrt(delta)) / (8 + 2 * Math.Pow(coef, 2));
			double diffp = Math.Abs(c1.X - xp);
			double diffm = Math.Abs(c1.X - xm);
			if (diffp > diffm) {
				double yp = coef * xp + p;
				return new Coord(xp, yp);
			} else {
				double ym = coef * xm + p;
				return new Coord(xm, ym);
			}
		}
	}
}
