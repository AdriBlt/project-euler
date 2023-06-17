// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Helpers
{
    using System;

    /**
     * Caution, the digit array is reversed!
     * d = sum_i(d_i * 10^i)
     */
    public static class DigitsHelpers
    {
        public static long[] ToDigits(long n)
        {
            int size = (int)Math.Ceiling(Math.Log10(n));
            long[] digits = new long[size];
            long r = n;
            for (int i = 0; i < size; i++)
            {
                digits[i] = r % 10;
                r /= 10;
            }

            return digits;
        }

        public static long ToNumber(long[] digits)
        {
            long n = 0;
            long shift = 1;
            foreach (long digit in digits)
            {
                n += digit * shift;
                shift *= 10;
            }

            return n;
        }

        public static string ToArrayString(long[] digits)
        {
            return "[" + string.Join(", ", digits) + "]";
        }
    }
}
