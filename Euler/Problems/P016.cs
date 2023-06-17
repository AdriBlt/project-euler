// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using Euler.Utils;

    public class P016 : AbstractProblem
    {
        public override void DebugProblem()
        {
            DebugResult(GetPowSum(2, 15), 26);
        }

        public override long ComputeSolution()
        {
            return GetPowSum(2, 1000);
        }

        private static long GetPowSum(int nombre, long puissance)
        {
            IntegerMap map = new IntegerMap(nombre);
            for (long i = 1; i < puissance; i++)
            {
                map.MultiplyBy(nombre);
            }

            return map.GetDigitSum();
        }
    }
}
