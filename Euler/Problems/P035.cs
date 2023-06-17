// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Euler.Utils;

    public class P035: AbstractProblem
    {

        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			List<long> primes = Functions.GetPrimesUnder(1000000);
			Dictionary<int, HashSet<long>> groupes = new Dictionary<int, HashSet<long>>();
			foreach (long p in primes) {
				int index = (int) Math.Floor(Math.Log10(p));
				if (!groupes.ContainsKey(index)) {
					groupes[index] = new HashSet<long>();
				}

				groupes[index].Add(p);
			}

			long count = 0;
			foreach (int g in groupes.Keys) {
				while (groupes[g].Count > 0) {
					long nextPrime = groupes[g].ToList()[0];
					HashSet<long> nextSet = new HashSet<long>();
					nextSet.Add(nextPrime);
					long prime = nextPrime;
					bool circular = true;
					for (int i = 0; i < g; i++) {
						long unite = prime % 10;
						long reste = prime / 10;
						prime = (long) (unite * Math.Pow(10, g) + reste);
						if (groupes[g].Contains(prime)) {
							nextSet.Add(prime);
						} else {
							circular = false;
							break;
						}
					}
					if (circular) {
						count += nextSet.Count;
						groupes[g].RemoveWhere(item => nextSet.Contains(item));
					} else {
						groupes[g].Remove(nextPrime);
					}
				}
			}
			
			return count;
		}
	}
}
