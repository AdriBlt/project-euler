// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Euler.Utils;

    public class P222: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			return 0;
		}

		public static class Minimum {
			public static double min = -1;

			public static bool isTooBig(double value) {
				if (min < 0) {
					return false;
				}
				return min < value;
			}

			public static void update(double value) {
				if (value < 0) {
					return;
				}
				if (min < 0 || min > value) {
					min = value;
				}
			}
		}

		private static int size = 21;

		private int rayonPipe = 50000;
		private HashSet<P222> fils;
		private List<Coord> pointsPrec;
		private List<int> rayonsPrec;
		private double taille;
		private string solution;

		public P222(HashSet<int> rayons): this(rayons, new List<Coord>(), new List<int>()) {
		}

		public P222(HashSet<int> rayons, List<Coord> anciensPoints, List<int> anciensRayons) {
			this.pointsPrec = anciensPoints;
			this.rayonsPrec = anciensRayons;
			this.fils = new HashSet<P222>();
			this.addFils(rayons);
			this.setMin();
			this.fils.Clear();
		}

		public P222(int[] rayons) {
			this.pointsPrec = new List<Coord>();
			this.rayonsPrec = new List<int>();
			this.fils = new HashSet<P222>();
			foreach (int rayon in rayons) {
				Coord point = this.getNextPoints(rayon);
				this.pointsPrec.Add(point);
				this.rayonsPrec.Add(rayon);
			}
			this.setMin();
		}

		public P222(List<int> rayons) {
			this.pointsPrec = new List<Coord>();
			this.rayonsPrec = new List<int>();
			this.fils = new HashSet<P222>();
			foreach (int rayon in rayons) {
				Coord point = this.getNextPoints(rayon);
				this.pointsPrec.Add(point);
				this.rayonsPrec.Add(rayon);
			}
			this.setMin();
		}

		private void addFils(HashSet<int> rayons) {
			foreach (int nextRayon in rayons) {
				// Set<Coord> nextPoints = this.getNextPoints(nextRayon);
				Coord prochainPoint = this.getNextPoints(nextRayon);

				if (Minimum.isTooBig(prochainPoint.Y + nextRayon)) {
					continue;
				}

				List<int> prochainRayonsPrec = new List<int>(this.rayonsPrec);
				prochainRayonsPrec.Add(nextRayon);

				HashSet<int> prochainRayonsAjout = new HashSet<int>(rayons);
				prochainRayonsAjout.Remove(nextRayon);

				// for (Coord prochainPoint : nextPoints) {
				List<Coord> prochainPointsPrec = new List<Coord>(this.pointsPrec);
				prochainPointsPrec.Add(prochainPoint);
				this.fils.Add(new P222(prochainRayonsAjout, prochainPointsPrec, prochainRayonsPrec));
				// }
			}
		}

		private Coord getNextPoints(int rayon) {
			HashSet<Coord> nextCoord = new HashSet<Coord>();

			int size = this.pointsPrec.Count;

			double x0 = rayon;
			double x1 = 2 * this.rayonPipe - rayon;

			if (size == 0) {
				// nextCoord.Add(new Coord(x0, x0));
				// // if (x0 != x1) {
				// // nextCoord.Add(new Coord(x1, x0));
				// // }
				// return nextCoord;
				return new Coord(x0, x0);
			}

			Coord lastPoint = this.pointsPrec[size - 1];
			int lastRayon = this.rayonsPrec[size - 1];

			double y0 = this.getY(x0, rayon, lastPoint, lastRayon);
			Coord coord0 = new Coord(x0, y0);
			if (this.isAdmissible(coord0, rayon)) {
				nextCoord.Add(coord0);
			}

			double y1 = this.getY(x1, rayon, lastPoint, lastRayon);
			Coord coord1 = new Coord(x1, y1);
			if (this.isAdmissible(coord1, rayon)) {
				nextCoord.Add(coord1);
			}

			if (nextCoord.Count == 1) {
				return nextCoord.ToList()[0];
			}

			if (y1 < y0) {
				// nextCoord.remove(coord0);
				return coord1;
			} else {
				// nextCoord.remove(coord1);
				return coord0;
			}

			// if (size > 1) {
			// Coord beforePoint = this.pointsPrec.get(size - 1);
			// int beforeRayon = this.rayonsPrec.get(size - 1);
			//
			// double yMax = Math.max(lastPoint.Y, beforePoint.Y);
			//
			// double m = -(lastPoint.X - beforePoint.X)
			// / (lastPoint.Y - beforePoint.Y);
			// double p = (Math.Pow(lastRayon + rayon, 2)
			// - Math.Pow(beforeRayon + rayon, 2)
			// - Math.Pow(lastPoint.X, 2)
			// + Math.Pow(beforePoint.X, 2)
			// - Math.Pow(lastPoint.Y, 2) + Math.Pow(
			// beforePoint.Y, 2))
			// / (2 * (beforePoint.Y - lastPoint.Y));
			// double a = 1 + m * m;
			// double b = 2 * (m * p - m * beforePoint.Y - beforePoint
			// .X);
			// double c = Math.Pow(beforePoint.X, 2)
			// + Math.Pow(p - beforePoint.Y, 2)
			// - Math.Pow(rayon + beforeRayon, 2);
			// double d = b * b - 4 * a * c;
			// if (d == 0) {
			// double x2 = -b / (2 * a);
			// double y2 = m * x2 + p;
			// if (y2 > yMax) {
			// Coord coord2 = new Coord(x2, y2);
			// if (this.isAdmissible(coord2, rayon)) {
			// nextCoord.Add(coord2);
			// }
			// }
			// } else if (d > 0) {
			// double x3 = (-b - Math.Sqrt(d)) / (2 * a);
			// double y3 = m * x3 + p;
			// if (y3 > yMax) {
			// Coord coord3 = new Coord(x3, y3);
			// if (this.isAdmissible(coord3, rayon)) {
			// nextCoord.Add(coord3);
			// }
			// }
			// double x4 = (-b + Math.Sqrt(d)) / (2 * a);
			// double y4 = m * x4 + p;
			// if (y4 > yMax) {
			// Coord coord4 = new Coord(x4, y4);
			// if (this.isAdmissible(coord4, rayon)) {
			// nextCoord.Add(coord4);
			// }
			// }
			// }
			// }

			// return nextCoord;
		}

		private bool isAdmissible(Coord point, int rayon) {
			if (point.X < rayon || point.X > 2 * this.rayonPipe - rayon || point.Y < 0) {
				return false;
			}

			for (int i = 0; i < this.pointsPrec.Count; i++) {
				Coord autrePoint = this.pointsPrec[i];
				int autreRayon = this.rayonsPrec[i];
				if (Math.Pow(point.X - autrePoint.X, 2) + Math.Pow(point.Y - autrePoint.Y, 2) < Math.Pow(rayon + autreRayon, 2)) {
					return false;
				}
			}

			return true;
		}

		private double getY(double x, int rayon, Coord pointPrec, int rayonPrec) {
			double difference = Math.Pow(rayon + rayonPrec, 2) - Math.Pow(x - pointPrec.X, 2);
			if (difference < 0) {
				return -1.0;
			}

			return pointPrec.Y + Math.Sqrt(difference);
		}

		private void setMin() {
			if (this.fils.Count == 0) {
				if (this.pointsPrec.Count == size && this.rayonsPrec.Count == size) {
					double value = this.pointsPrec[size - 1].Y + this.rayonsPrec[size - 1];
					Minimum.update(value);
					this.taille = value;
					this.solution = this.makeSol();
					return;
				}

				return;
			}

			Dictionary<Double, string> filsMin = new Dictionary<Double, string>();
			foreach (P222 son in this.fils) {
				double val = son.getTaille();
				if (val > 0) {
					filsMin[val] = son.getSol();
				}
			}

			if (filsMin.Count > 0) {
				this.taille = filsMin.Keys.Min();
				this.solution = filsMin[this.taille];
			}

			return;
		}

		private string makeSol() {
			string sol = "[";
			foreach (int rayon in this.rayonsPrec) {
				sol += " " + (rayon / 1000).ToString();
			}
			sol += " ]";
			return sol;
		}

		public string getSol() {
			return this.solution;
		}

		public double getTaille() {
			return this.taille;
		}

		/**
		* @param args
		*/
		public static void main(string[] args) {
			HashSet<int> rayons = new HashSet<int>();
			int firstBall = 30;
			int lastBall = firstBall + P222.size;
			for (int p = firstBall; p < lastBall; p++) {
				rayons.Add(p * 1000);
			}
			P222 pipe = new P222(rayons);
			Console.WriteLine(pipe.getTaille() + " " + pipe.getSol());
			Console.WriteLine(Minimum.min);

			List<int> liste = buildListe(firstBall, lastBall);
			P222 pipe1 = new P222(liste);
			Console.WriteLine(pipe1.getTaille() + " " + pipe1.getSol());
		}

		private static List<int> buildListe(int firstBall, int lastBall) {
			List<int> liste = new List<int>();
			for (int i = lastBall - 1; i >= firstBall; i--) {
				if (i % 2 == 1) {
					liste.Add(i * 1000);
				}
			}
			for (int i = firstBall; i < lastBall; i++) {
				if (i % 2 == 0) {
					liste.Add(i * 1000);
				}
			}
			return liste;
		}
	}
}
