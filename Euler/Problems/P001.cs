// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P001 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(Get3Or5MultipleSumBelow(10), 23);
        }

        public override long ComputeSolution()
        {
            return Get3Or5MultipleSumBelow(1000);
        }

        private long Get3Or5MultipleSumBelow(long maxValue)
        {
            int d1 = 3;
            int d2 = 5;
            int sum = 0;
            for (int i = 1; i < maxValue; i++)
            {
                if (i % d1 == 0 || i % d2 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
