// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P025 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(getFibonacciWithDigit(3),-1);
        }

        public override long ComputeSolution()
        {
            return getFibonacciWithDigit(1000);
        }

		private static long getFibonacciWithDigit(int digit) {
			IntegerMap[] dictionary = new IntegerMap[3];
			dictionary[0] = new IntegerMap();
			dictionary[1] = new IntegerMap(1);
			dictionary[2] = new IntegerMap(1);
			long index = 2;
			int shortIndex = (int) (index % 3);
			while (dictionary[shortIndex].GetSize() < digit) {
				index++;
				shortIndex = (int) (index % 3);
				dictionary[shortIndex].MultiplyBy(0);
				for (int i = 0; i < 3; i++) {
					if (i == shortIndex) {
						continue;
					}
					dictionary[shortIndex].Add(dictionary[i]);
				}
			}
			return index;
		}

		public static long getFibonacci(int number) {
			double sq = Math.Sqrt(5);
			return (long) ((Math.Pow((1 + sq) / 2, number) - Math.Pow((1 - sq) / 2,
					number)) / sq);
		}
	}
}