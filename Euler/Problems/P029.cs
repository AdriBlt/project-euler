// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System.Collections.Generic;
    using Euler.Utils;

    public class P029: AbstractProblem
    {

        public override void DebugProblem()
        {
            DebugResult(getNumberCombinatoire(5), -1);
        }

        public override long ComputeSolution()
        {
			return getNumberCombinatoire(100);
		}
		
		private static int getNumberCombinatoire(int max) {
			HashSet<string> set = new HashSet<string>();
			for (int a = 2; a <= max; a++) {
				IntegerMap Dictionary = new IntegerMap(a);
				for (int b = 2; b <= max; b++) {
					Dictionary.MultiplyBy(a);
					string number = Dictionary.ToString();
					set.Add(number);
				}
			}
			
			return set.Count;
		}
	}
}
