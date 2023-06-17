// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P032: AbstractProblem
    {

        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			List<long> divisors = new List<long>();
			for (long i = 0; i < 9999; i++) {
				if (Functions.IsPandigital(i.ToString())>=0) {
					divisors.Add(i);
				}
			}

			HashSet<long> products = new HashSet<long>();
			for (int i = 0; i < divisors.Count; i++) {
				long a = divisors[i];
				for (int j = i + 1; j < divisors.Count; j++) {
					long b = divisors[j];
					string multiplicateurs = a.ToString() + b.ToString();
					if (Functions.IsPandigital(multiplicateurs)>=0) {
						long c = a * b;
						if (Functions.IsPandigital(multiplicateurs + c.ToString())==1) {
							products.Add(c);
						}
					}
				}
			}

			long sum = 0;
			foreach (long i in products) {
				sum += i;
			}
			
			return sum;
		}
	}
}
