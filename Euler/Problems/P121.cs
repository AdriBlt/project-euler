// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P121: AbstractProblem
    {
        public override void DebugProblem()
        {
			TestProbaOnTour(4);
            DebugResult(GetProbaWin(4), -1);
        }

        public override long ComputeSolution()
        {
			TestProbaOnTour(15);
			return GetProbaWin(15);
		}

		private static int GetProbaWin(int tours) {
			long denum = Functions.GetPermutationNumber(tours + 1);
			int winMin = (tours % 2 == 0? tours/2 : (tours-1)/2) + 1;
			long num = 1;
			for (int nbWin = winMin; nbWin < tours; nbWin++) {
				num += getProbaWinOnTour(nbWin, tours);
			}

			Console.WriteLine(num + "/" + denum);
			double proba = 1.0 * num / denum;
			Console.WriteLine(proba);
			double prize = 1.0  * denum / num;
			Console.WriteLine(prize);
			return (int) Math.Floor(prize);
		}

		private static long getProbaWinOnTour(int nbWin, int tours) {
			int nbLose = tours - nbWin;
			HashSet<int> tab = new HashSet<int>();
			for (int i = 1; i <= tours; i++) {
				tab.Add(i);
			}

			long sortie = subProd(nbLose, tab);
			return sortie;
		}

		private static long subProd(int nb, HashSet<int> tab) {
			long sortie = 0;
			if (nb == 1) {
				foreach (int i in tab) {
					sortie += i;
				}
			} else {
				foreach (int i in tab) {
					HashSet<int> subTab = new HashSet<int>();
					foreach (int j in tab) {
						if (j > i) {
							subTab.Add(j);
						}
					}
					
					sortie += i * subProd(nb - 1, subTab);
				}
			}

			return sortie;
		}

		private static void TestProbaOnTour(int tour) {
			for(int i = 0; i < tour ; i++){
				Console.WriteLine(i + " / " + tour + " : " + getProbaWinOnTour(i, tour));
			}
		}
	}
}
