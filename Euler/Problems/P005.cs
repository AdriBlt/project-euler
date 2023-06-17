// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P005 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(DivisibleByAll(10), 2520);
        }

        public override long ComputeSolution()
        {
            return DivisibleByAll(20);
        }

        private long DivisibleByAll(int max)
        {
            long nombre = max;
            for (int i = 2; i < max; i++)
            {
                if (nombre % i > 0)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (j * nombre % i == 0)
                        {
                            nombre = nombre * j;
                            break;
                        }
                    }
                }
            }
            return nombre;
        }
    }
}
