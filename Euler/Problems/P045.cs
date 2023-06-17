// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P0: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(,);
        }

        public override long ComputeSolution()
        {
			long triangle = 0;
			int n = 0;
			long sol = 0;
			while (sol < 3) {
				n++;
				triangle += n;
				if (Functions.IsPentagonal(triangle) && Functions.IsHexagonal(triangle)) {
					sol++;
				}
			}

			return sol;
		}
	}
}
