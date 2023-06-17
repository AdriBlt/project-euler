// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    public class P031: AbstractProblem
    {

        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			int[] tab = { 1, 2, 5, 10, 20, 50, 100, 200 };
			int sum = 200;

			int size = tab.Length;
			int[] numberPiece = new int[size];
			for (int i = 0; i < size; i++) {
				numberPiece[i] = 0;
			}
			int cardinal = 0;
			int total = 0;
			int index = 0;

			while (true) {
				if (index == size) {
					break;
				}
				int nextTotal = tab[index] + total;
				if (nextTotal > sum) {
					total -= tab[index] * numberPiece[index];
					numberPiece[index] = 0;
					index++;
					continue;
				}
				if (nextTotal <= sum) {
					if (nextTotal == sum) {
						cardinal++;
					}
					total = nextTotal;
					numberPiece[index]++;
					index = 0;
				}
			}
			
			return cardinal;
		}
	}
}
