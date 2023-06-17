// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P051: AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(getSmallestPrimeFromFamillyOf(6), -1);
            DebugResult(getSmallestPrimeFromFamillyOf(7), -1);
        }

        public override long ComputeSolution()
        {
			return getSmallestPrimeFromFamillyOf(8);
		}

		private static long getSmallestPrimeFromFamillyOf(int nombre) {
			List<long> primes = Functions.GetPrimesUnder(1000000);
			foreach (long p in primes) {
				for (int i = 0; i <= 10 - nombre; i++) {
					int recurrence = containsDigitsOf(p, i);
					for (int d = 1; d <= recurrence; d++) {
						if (getFamillySize(p, i, d) >= nombre) {
							return p;
						}
					}
				}
			}

			return 0;
		}

		private static int getFamillySize(long p, int chiffre, int digitChange) {
			int[] primeChiffres = getIntArray(p);
			return getFamillySize(primeChiffres, digitChange, chiffre, 0);
		}

		private static int getFamillySize(int[] tab, int digit, int nbChange, int index) {
			int size = tab.Length;
			if (nbChange > 0) {
				int max = -1;
				for (int i = index; i < size; i++) {
					if (tab[i] != digit) {
						continue;
					}

					int[] nextTab = new int[size];
					for (int j = 0; j < size; j++) {
						nextTab[j] = tab[j];
					}

					nextTab[i] = -1;
					print(nextTab);
					int nextValue = getFamillySize(nextTab, digit, nbChange - 1, i + 1);
					if (max < nextValue) {
						max = nextValue;
					}
				}

				return max;
			} else {
				int nombrePrime = 1;
				for (int i = digit + 1; i < 10; i++) {
					int[] nextTab = new int[size];
					for (int j = 0; j < size; j++) {
						if (tab[j] < 0) {
							nextTab[j] = i;
						} else {
							nextTab[j] = tab[j];
						}
					}

					long pp = getLong(nextTab);
					if (Functions.IsPrime(pp)) {
						nombrePrime++;
					}
				}

				if (nombrePrime >= 8) {
					print(tab);
				}

				return nombrePrime;
			}
		}

		private static void print(int[] tab) {
			Console.Write("[");
			for (int o = 0; o < tab.Length; o++) {
				Console.Write(" " + tab[o]);
			}

			Console.WriteLine(" ]");
		}

		private static int[] getIntArray(long p) {
			int n = Functions.GetDigitNumber(p);
			int[] tab = new int[n];
			long nombre = p;
			for (int i = 0; i < n; i++) {
				tab[n - i - 1] = (int) (nombre % 10);
				nombre = nombre / 10;
			}
			return tab;
		}

		private static long getLong(int[] tab) {
			long nombre = 0;
			for (int i = 0; i < tab.Length; i++) {
				nombre = nombre * 10 + tab[i];
			}

			return nombre;
		}

		private static int containsDigitsOf(long p, int chiffre) {
			string prime = p.ToString();
			int nombre = 0;
			for (int i = 0; i < prime.Length; i++) {
				if (int.Parse(prime.Substring(i, 1)) == chiffre) {
					nombre++;
				}
			}
			
			return nombre;
		}
	}
}
