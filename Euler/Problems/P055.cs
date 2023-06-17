// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System.Collections.Generic;
    using Euler.Utils;

    public class P055: AbstractProblem
    {
		private static Dictionary<string, int> LychrelNumbers = new Dictionary<string, int>();

        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			return GetLychrelBelow(10000);
		}

		private static int GetLychrelBelow(int max) {
			int sortie = 0;
			for (int i = max - 1; i > 0; i--) {
				if (IsLychrel(new IntegerMap(i), 0) < 0) {
					P055.LychrelNumbers[new IntegerMap(i).ToString()] = -1;
					// Console.WriteLine(i);
					sortie++;
				}
			}

			return sortie;
		}

		private static int IsLychrel(IntegerMap IntegerMap, int iter) {
			if (P055.LychrelNumbers.ContainsKey(IntegerMap.ToString())) {
				return P055.LychrelNumbers[IntegerMap.ToString()];
			}

			int borne = 100;
			if (iter > borne) {
				return -1;
			}

			IntegerMap reverse = IntegerMap.Reverse();
			reverse.Add(IntegerMap);
			if (Functions.IsPalindrome(reverse.ToString())) {
				P055.LychrelNumbers[IntegerMap.ToString()] = 1;
				P055.LychrelNumbers[IntegerMap.Reverse().ToString()] = 1;
				return 1;
			} else {
				int value = IsLychrel(reverse, iter + 1);
				if (value < 0) {
					return -1;
				}

				P055.LychrelNumbers[IntegerMap.ToString()] = 1 + value;
				P055.LychrelNumbers[IntegerMap.Reverse().ToString()] = 1 + value;
				return 1 + value;
			}
		}
	}
}
