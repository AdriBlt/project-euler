// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P048: AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(long.Parse(getSelfPowerSum(10)), -1);
        }

        public override long ComputeSolution()
        {
			string sortie = getSelfPowerSum(1000);
			return long.Parse(sortie.Substring(sortie.Length - 10));
		}

		private static string getSelfPowerSum(int max) {
			BigIntegerMap somme = new BigIntegerMap();
			for(int i = 1; i <= max; i++) {
				BigIntegerMap mapI = new BigIntegerMap(i);
				for(int m = 1; m < i; m++){
					mapI.Multiply(i);
				}

				somme.Add(mapI);
			}

			return somme.ToString();
		}
	}
}
