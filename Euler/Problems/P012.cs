// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P012 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetTriangleNumberWithDivisors(5), 28);
        }

        public override long ComputeSolution()
        {
            return GetTriangleNumberWithDivisors(500);
        }

        private static long GetTriangleNumberWithDivisors(int nbDivisors)
        {
            long nbTriangle = 0;
            for (int i = 1; ; i++)
            {
                nbTriangle += i;
                if (GetDivisorsSize(nbTriangle) >= nbDivisors)
                {
                    return nbTriangle;
                }
            }
        }

        private static int GetDivisorsSize(long number)
        {
            int nbDiviseur = 0;
            long root = (long)Math.Sqrt(number);
            if (Math.Pow(root, 2) == number)
            {
                nbDiviseur++;
            }

            for (int i = 1; i < root; i++)
            {
                if (number % i == 0)
                {
                    nbDiviseur += 2;
                }
            }

            return nbDiviseur;
        }

    }
}
