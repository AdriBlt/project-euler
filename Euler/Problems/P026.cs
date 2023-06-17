// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;

    public class P026: AbstractProblem
    {

        public override void DebugProblem()
        {
            for (int i = 2; i <= 10; i++)
            {
                int length = GetSequenceLength(i);
                Console.WriteLine($"{i} : {length}");
            }
        }

        public override long ComputeSolution()
        {
            int maxSequenceIndex = 0;
            int maxSequenceLength = 0;

            for (int i = 2; i < 1000; i++)
            {
                int length = GetSequenceLength(i);

                if (length > maxSequenceLength)
                {
                    maxSequenceIndex = i;
                    maxSequenceLength = length;
                }
            }

            return maxSequenceIndex;
        }

        private static int GetSequenceLength(int i)
        {
            int[] foundRemainders = new int[i];
            int value = 1;
            int position = 0;

            while (foundRemainders[value] == 0 && value != 0)
            {
                foundRemainders[value] = position;
                value *= 10;
                value %= i;
                position++;
            }

            if (value == 0)
            {
                return 0;
            }

            return position - foundRemainders[value];
        }
    }
}
