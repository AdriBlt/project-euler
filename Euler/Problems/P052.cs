// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Helpers;

    public class P052 : AbstractProblem
    {
        public override void DebugProblem()
        {
            Console.WriteLine(DigitsHelpers.ToArrayString(DigitsHelpers.ToDigits(13646948)));
        }

        public override long ComputeSolution()
        {
            return 0;
        }

        private static bool HaveSameDigits(int a, int b)
        {
            return false;
        }
    }
}
