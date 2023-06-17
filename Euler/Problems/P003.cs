// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using Euler.Utils;

    public class P003 : AbstractProblem
    {
        public override void DebugProblem()
        {
            long deb = 13195;
            long fin = 0;
            long coef = 1;
            DebugResult(GetLargestPrimeFactors(deb, fin, coef), 29);
        }

        public override long ComputeSolution()
        {
            long deb = 600851;
            long fin = 475143;
            long coef = 1000000;
            return GetLargestPrimeFactors(deb, fin, coef);
        }

        private long GetLargestPrimeFactors(long deb, long fin, long coef)
        {
            long upRoot = (long)(Math.Sqrt(deb + 1) * Math.Sqrt(coef));
            for (long i = upRoot; i > 0; i--)
            {
                long debRest = deb % i;
                long finQuot = debRest * coef + fin;
                long finRest = finQuot % i;
                if (finRest == 0)
                {
                    if (i.IsPrime())
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
