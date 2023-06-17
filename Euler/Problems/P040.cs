// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P040: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			long index = 0;
			long prod = 1;
			long courant = 0;
			while (index <= 1000000) {
				courant++;
				int digit = Functions.GetDigitNumber(courant);
				for (int i = 0; i < digit; i++) {
					index++;
					if (Math.Log10(index) % 1 == 0) {
						int chiffre = int.Parse(courant.ToString().Substring(i, 1));
						prod *= chiffre;
					}
				}
			}
			
			return prod;
		}
	}
}
