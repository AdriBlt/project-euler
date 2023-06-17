// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P015 : AbstractProblem
    {
        public override void DebugProblem()
        {
			DebugResult(GetNumberOfRoutesInSquaredGrid(2), 6);
        }

        public override long ComputeSolution()
        {
            return GetNumberOfRoutesInSquaredGrid(20);
        }

        private long GetNumberOfRoutesInSquaredGrid(int size)
        {
            return Functions.GetBinomialCoeff(size, 2 * size);
        }
	}
}