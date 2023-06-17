// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P030: AbstractProblem
    {

        public override void DebugProblem()
        {
            DebugResult(getSumDigitPowSum(4), -1);
        }

        public override long ComputeSolution()
        {
			return getSumDigitPowSum(5);
		}
		
		private static long getSumDigitPowSum(int pow) {
			long somme = 0;
			for (long i = 10; i < 1000000; i++) {
				IntegerMap Dictionary = new IntegerMap(i);
				long sum = Dictionary.GetDigitPowSum(pow);
				if (sum == i) {
					somme += i;
				}
			}
			return somme;
		}
	}
}