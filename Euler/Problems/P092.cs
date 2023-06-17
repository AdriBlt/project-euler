// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P092: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
        }

        public override long ComputeSolution()
        {
			int number = 0;
			int max = 10000000;
			Dictionary<long, bool> results = new Dictionary<long, bool>();
			results[1] = false;
			results[89] = true;
			HashSet<int> passages = new HashSet<int>();
			long iter, nb, reste;
			for (int i = 1; i < max; i++ ) {
				iter = i;
				for(;;) {
					if (results.ContainsKey(iter)) {
						bool b = results[iter];
						foreach (int j in passages) {
							results[j] = b;
						}

						if (b) {
							number++;
						}

						passages.Clear();
						break;
					}

					nb = iter;
					iter = 0;
					while (nb > 0) {
						reste = nb % 10;
						nb = nb / 10;
						iter += (long)Math.Pow(reste, 2);
					}
				}
			}
			
			return number;
		}
	}
}
