// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P004 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetLargestPalindromeProductOfDigit(2), 9009);
        }

        public override long ComputeSolution()
        {
            return GetLargestPalindromeProductOfDigit(3);
        }

        private long GetLargestPalindromeProductOfDigit(int nbDigit)
        {
            long maxDigit = (long)Math.Pow(10, nbDigit);
            long max = (maxDigit - 1) * (maxDigit - 1);
            for (long i = max; i > 0; i--)
            {
                if (i.IsPalindrome())
                {
                    if (i.IsDigitProduct(nbDigit))
                    {
                        return i;
                    }
                }
            }

            return 0;
        }
    }
}