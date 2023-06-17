// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Helpers
{
    using System;
    using Euler.Utils;

    public static class RomanExtensions
    {
        public static int GetValue(this Roman roman) => (int)roman;

        public static string GetName(this Roman roman) => roman.ToString();

        public static int ToRomanValue(this string roman)
        {
            int value = 0;
            Roman? lastLetter = null;
            foreach (char letter in roman)
            {
                if (!Enum.TryParse(letter.ToString(), out Roman courant))
                {
                    throw new ArgumentException(nameof(roman));
                }

                if (lastLetter.HasValue && lastLetter.Value.GetValue() > courant.GetValue())
                {
                    value -= courant.GetValue();
                }
                else
                {
                    value += courant.GetValue();
                }

                lastLetter = courant;
            }

            return value;
        }

        public static string ToRoman(this int value)
        {
            int units = value % 10;
            int tens = value / 10 % 10;
            int hundreds = value / 100 % 10;
            int thousands = value / 1000;

            string roman = GetUnitRoman(hundreds, 100) + GetUnitRoman(tens, 10) + GetUnitRoman(units, 1);
            string thousandKey = Roman.M.GetName();
            for (int i = 0; i < thousands; i++)
            {
                roman = thousandKey + roman;
            }

            return roman;
        }

        private static string GetUnitRoman(int number, int unit)
        {
            return GetValue(number, GetRomanUnit(unit), GetRomanUnit(5 * unit), GetRomanUnit(10 * unit));
        }

        private static Roman GetRomanUnit(int unit)
        {
            foreach (Roman roman in Enum.GetValues(typeof(Roman)))
            {
                if (unit == roman.GetValue())
                {
                    return roman;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(unit));
        }

        private static string GetValue(int value, Roman simple, Roman quinte, Roman deca)
        {
            switch (value)
            {
                case 1:
                    return simple.GetName();
                case 2:
                    return simple.GetName() + simple.GetName();
                case 3:
                    return simple.GetName() + simple.GetName() + simple.GetName();
                case 4:
                    return simple.GetName() + quinte.GetName();
                case 5:
                    return quinte.GetName();
                case 6:
                    return quinte.GetName() + simple.GetName();
                case 7:
                    return quinte.GetName() + simple.GetName() + simple.GetName();
                case 8:
                    return quinte.GetName() + simple.GetName() + simple.GetName() + simple.GetName();
                case 9:
                    return simple.GetName() + deca.GetName();
                default:
                    return "";
            }
        }
    }
}