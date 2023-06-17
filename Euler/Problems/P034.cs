// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P034: AbstractProblem
    {

        public override void DebugProblem()
        {
            DebugResult(new IntegerMap(145).GetDigitFactorialSum(), -1);
        }

        public override long ComputeSolution()
        {
			IntegerMap sum = new IntegerMap();
			for (long i = 3; i < 1000000; i++) {
				if (new IntegerMap(i).GetDigitFactorialSum() == i) {
					sum.Add(i);
				}
			}

			return sum.ToLong();
		}
	}
}
