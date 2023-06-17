// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P002 : AbstractProblem
    {
        public override void DebugProblem()
        {
            Console.WriteLine("Fibonacci");
            long valMax = 100;
            long v1 = 1;
            long v2 = 2;
            Console.WriteLine(v1);
            Console.WriteLine(v2);
            while (v2 < valMax)
            {
                long v3 = v1 + v2;
                v1 = v2;
                v2 = v3;
                Console.WriteLine(v3);
            }
        }

        public override long ComputeSolution()
        {
            long valMax = 4000000;
            long sum = 0;
            long v1 = 1;
            long v2 = 2;
            while (v2 < valMax)
            {
                if (v2 % 2 == 0)
                {
                    sum += v2;
                }

                long v3 = v1 + v2;
                v1 = v2;
                v2 = v3;
            }

            return sum;
        }
    }
}
