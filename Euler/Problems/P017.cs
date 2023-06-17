// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    public class P017 : AbstractProblem
    {
        private readonly int[] _units = {
                0, // (zero)
                3, // one
                3, // two
                5, // three
                4, // four
                4, // five
                3, // six
                5, // seven
                5, // eight
                4, // nine
                3, // ten
                6, // eleven
                6, // twelve
                8, // thirteen
                8, // fourteen
                7, // fifteen
                7, // sixteen
                9, // seventeen
                8, // eighteen
                8 // nineteen
            };
        private readonly int[] _tens = {
                0, // (zero)
                0, // (ten)
                6, // twenty
                6, // thirty
                5, // forty
                5, // fifty
                5, // sixty
                7, // seventy
                6, // eighty
                6 // ninety
            };
        private readonly int _hundreds = 7; // hundred
        private readonly int _thousands = 8; // thousand
        private readonly int _and = 3; // and

        public override void DebugProblem()
        {
            DebugResult(CountLettersBelow(5), 19);
        }

        public override long ComputeSolution()
        {
            return CountLettersBelow(1000);
        }

        private long CountLettersBelow(long max)
        {
            long sum = 0;
            for (long i = 1; i <= max; i++)
            {
                sum += GetNumberLetterCount(i);
            }

            return sum;
        }

        private long GetNumberLetterCount(long number)
        {
            long count = 0;
            int number100 = (int)(number % 100);
            if (number100 < 20)
            {
                count += _units[number100];
            }
            else
            {
                int units100 = number100 % 10;
                int tens100 = number100 / 10;
                count += _units[units100] + _tens[tens100];
            }

            int number1000 = (int)(number / 100);
            if (number1000 > 0)
            {
                int hundreds = number1000 % 10;
                int thousands = number1000 / 10;
                if (hundreds > 0)
                {
                    count += _units[hundreds] + _hundreds;
                }

                if (thousands > 0)
                {
                    count += _units[thousands] + _thousands;
                }

                if (number100 > 0)
                {
                    count += _and;
                }
            }

            return count;
        }
    }
}