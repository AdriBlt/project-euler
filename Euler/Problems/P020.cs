// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P020 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(Functions.GetFactorielDigitSum(10), 27);
        }

        public override long ComputeSolution()
        {
            return Functions.GetFactorielDigitSum(100);
        }
    }
}
