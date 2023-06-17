// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P044: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			long min = int.MaxValue;
			List<int> pentagons = new List<int>();
			for (int i = 1; i < 10000; i++) {
				int newPentagon = i * (3 * i - 1) / 2;
				foreach (int p in pentagons) {
					int difference = newPentagon - p;
					if (min < difference) {
						continue;
					}

					if (!Functions.IsPentagonal(difference)) {
						continue;
					}

					int somme = newPentagon + p;
					if (!Functions.IsPentagonal(somme)) {
						continue;
					}

					if (min > difference) {
						min = difference;
						Console.WriteLine(difference);
					}
				}

				pentagons.Add(newPentagon);
			}
			
			return min;
		}
	}
}
