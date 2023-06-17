// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P028: AbstractProblem
    {
		enum Sens {
			Right, Down, Left, Up
		};

        public override void DebugProblem()
        {
            DebugResult(getSpiralDiagSum(5), -1);
        }

        public override long ComputeSolution()
        {
			return getSpiralDiagSum(1001);
		}

		private static long getSpiralDiagSum(int size) {
			long max = (long) Math.Pow(size, 2);
			long[][] tab = new long[size][];
			for (int i = 0; i < size; i++) {
				tab[i] = new long[size];
				for (int j = 0; j < size; j++) {
					tab[i][j] = 0;
				}
			}

			int mid_i = size / 2;
			int mid_j = size / 2;
			tab[mid_i][mid_j] = 1;
			Sens sens = Sens.Right;
			mid_j++;
			long diag = 1;
			for (long val = 2; val <= max; val++) {
				tab[mid_i][mid_j] = val;
				if (mid_i == mid_j || mid_i == size - 1 - mid_j) {
					diag += val;
				}
				switch (sens) {
				case Sens.Right:
					if (tab[mid_i + 1][mid_j] == 0) {
						mid_i++;
						sens = Sens.Down;
					} else {
						mid_j++;
					}
					break;
				case Sens.Down:
					if (tab[mid_i][mid_j - 1] == 0) {
						mid_j--;
						sens = Sens.Left;
					} else {
						mid_i++;
					}
					break;
				case Sens.Left:
					if (tab[mid_i - 1][mid_j] == 0) {
						mid_i--;
						sens = Sens.Up;
					} else {
						mid_j--;
					}
					break;
				case Sens.Up:
					if (tab[mid_i][mid_j + 1] == 0) {
						mid_j++;
						sens = Sens.Right;
					} else {
						mid_i--;
					}
					break;
				}
			}

			return diag;
		}
	}
}
