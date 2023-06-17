// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P109: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			int somme = 0;
			int[] multi = { 1, 2, 3 };
			// string[] lettre = { "S", "D", "T" };
			int[] value = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25 };
			foreach (int v1 in value) {
				if (v1 == 0) {
					continue;
				}

				foreach (int v2 in value) {
					if (v2 == 0) {
						if (condition(2 * v1)) {
							// Console.WriteLine("D" + v1);
							somme++;
						}

						continue;
					}

					foreach (int m2 in multi) {
						if (v2 == 25 && m2 == 3) {
							continue;
						}

						foreach (int v3 in value) {
							if (v3 == 0) {
								if (condition(2 * v1 + m2 * v2)) {
									// Console.WriteLine(lettre[m2 - 1] + v2 + "\tD" + v1);
									somme++;
								}

								continue;
							}

							foreach (int m3 in multi) {
								if (v3 == 25 && m3 == 3) {
									continue;
								}

								if (m3 < m2) {
									continue;
								}

								if (m3 == m2 && v3 < v2) {
									continue;
								}

								if (condition(2 * v1 + m2 * v2 + m3 * v3)) {
									// Console.WriteLine(lettre[m3 - 1] + v3 + "\t" + lettre[m2 - 1] + v2 + "\tD" + v1);
									somme++;
								}
							}
						}
					}
				}
			}

			return somme;
		}

		private static bool condition(int i) {
			// return i == 6;
			// return true;
			return i < 100;
		}
	}
}
