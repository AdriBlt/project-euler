// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P036: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			IntegerMap sum = new IntegerMap();
			for (int i = 1; i < 1000000; i+=2) {
				if (Functions.IsPalindrome(i)) {
					if (Functions.IsPalindrome(Functions.ToBinary(i))) {
						sum.Add(i);
					}
				}
			}
			
			return sum.ToLong();
		}
	}
}
