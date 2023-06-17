// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    public class P019 : AbstractProblem
    {
        private readonly int[] _dayInMonth = {
            31, // January
            28, // February
            31, // March
            30, // April
            31, // May
            30, // June
            31, // July
            31, // August
            30, // September
            31, // October
            30, // November
            31, // December
        };

        public override void DebugProblem()
        {
        }

        public override long ComputeSolution()
        {
            return GetNumberOfSundayTheFirst(1901, 2000);
        }

        public long GetNumberOfSundayTheFirst(int fromYear, int toYear)
        {
            int count = 0;
            int day = 1;
            for (int year = 1900; year <= toYear; year++)
            {
                for (int month = 0; month < 12; month++)
                {
                    if (year >= fromYear && day == 0)
                    {
                        count++;
                    }

                    day += _dayInMonth[month];
                    if (month == 1 && IsLeapYear(year))
                    {
                        day++;
                    }

                    day = day % 7;
                }
            }

            return count;
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 400 == 0)
                {
                    return true;
                }

                if (year % 100 == 0)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }

}
