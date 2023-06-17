// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P038: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			IntegerMap max = new IntegerMap();
			for (long i = 1; i < 10000000; i++) {
				long multiple = i;
				string str = multiple.ToString();
				int pandigit = Functions.IsPandigital(str);
				while (pandigit >= 0) {
					if (pandigit == 1){
						Console.WriteLine("int=" + i + " : " + str);
						max.Max(new IntegerMap(str));
						break;
					}

					multiple += i;
					str = str + multiple.ToString();
					pandigit = Functions.IsPandigital(str);
				}
			}
			
			return max.ToLong();
		}
	}
}
