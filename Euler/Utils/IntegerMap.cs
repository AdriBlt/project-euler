// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerMap : IEquatable<IntegerMap>
    {
        private readonly Dictionary<int, int> _mapping;

        public IntegerMap()
        {
            _mapping = new Dictionary<int, int>();
            Add(0);
        }

        public IntegerMap(int value) : this()
        {
            Add(value);
        }

        public IntegerMap(long value) : this()
        {
            Add(value);
        }

        public IntegerMap(IntegerMap value) : this()
        {
            Add(value);
        }

        public IntegerMap(string str) : this()
        {
            int size = str.Length;
            for (int i = 0; i < size; i++)
            {
                int chiffre = int.Parse(str.Substring(i, 1));
                Add(chiffre, size - 1 - i);
            }
        }

        public void Add(int chiffre, int index)
        {
            int somme = chiffre + GetDigit(index);
            int unite = somme % 10;
            SetDigit(index, unite);
            int dizaine = somme / 10;
            if (dizaine > 0)
            {
                Add(dizaine, index + 1);
            }
        }

        public void DivideBy(int d)
        {
            if (_mapping.Count == 0)
            {
                Add(0);
                return;
            }

            int max = GetSize();
            int retenue = 0;
            for (int i = max - 1; i >= 0; i--)
            {
                int value = 10 * retenue + GetDigit(i);
                SetDigit(i, value / d);
                retenue = value % d;
            }

            GetSize();
        }

        public void MultiplyBy(int m)
        {
            if (_mapping.Count == 0)
            {
                Add(0);
                return;
            }

            int max = GetSize();
            int retenue = 0;
            for (int i = 0; i <= max; i++)
            {
                int multi = m * GetDigit(i) + retenue;
                int unite = multi % 10;
                SetDigit(i, unite);
                retenue = multi / 10;
            }

            int index = max;
            while (retenue > 0)
            {
                index++;
                int unite = retenue % 10;
                _mapping[index] = unite;
                retenue = retenue / 10;
            }
        }

        public void MultiplyBy(double d)
        {
            if (_mapping.Count == 0)
            {
                Add(0);
                return;
            }

            int max = GetSize();
            int retenue = 0;
            for (int i = 0; i < max; i++)
            {
                int multi = (int)(d * GetDigit(i) + retenue);
                int unite = multi % 10;
                SetDigit(i, unite);
                retenue = multi / 10;
            }

            int index = max;
            while (retenue > 0)
            {
                index++;
                int unite = retenue % 10;
                SetDigit(index, unite);
                retenue = retenue / 10;
            }
        }

        public void MultiplyBy(IntegerMap multi)
        {
            IntegerMap copie = new IntegerMap(this);
            MultiplyBy(0);
            for (int i = 0; i < multi.GetSize(); i++)
            {
                IntegerMap ajout = new IntegerMap(copie);
                copie.MultiplyBy(10);
                ajout.MultiplyBy(multi.GetDigit(i));
                Add(ajout);
            }
        }

        public override string ToString()
        {
            string output = "";
            int max = GetMaxKey();
            for (int i = 0; i <= max; i++)
            {
                output = GetDigit(i) + output;
            }

            return output;
        }

        public long ToLong()
        {
            long output = 0;
            long coef = 1;
            int max = GetMaxKey();
            for (int i = 0; i <= max; i++)
            {
                output += coef * GetDigit(i);
                coef *= 10;
            }

            return output;
        }

        public long GetDigitSum()
        {
            long digitSum = 0;
            int max = GetMaxKey();
            for (int i = 0; i <= max; i++)
            {
                digitSum += GetDigit(i);
            }

            return digitSum;
        }

        public void Add(int nombre)
        {
            Add(nombre, 0);
        }

        public void Add(long value)
        {
            long nombre = value;
            int index = 0;
            while (nombre > 0)
            {
                int val = (int)(nombre % 100);
                Add(val, index);
                index += 2;
                nombre = nombre / 100;
            }
        }

        public void Add(IntegerMap map)
        {
            for (int i = 0; i <= map.GetSize(); i++)
            {
                if (map._mapping.ContainsKey(i))
                {
                    Add(map.GetDigit(i), i);
                }
            }
        }

        public int GetSize()
        {
            int maxKey = GetMaxKey();
            if (GetDigit(maxKey) > 0)
            {
                return maxKey + 1;
            }

            return 0;
        }

        private int GetMaxKey()
        {
            while (_mapping.Count > 0)
            {
                int maxIndex = _mapping.Keys.Max();
                if (GetDigit(maxIndex) > 0)
                {
                    return maxIndex;
                }
                else
                {
                    _mapping.Remove(maxIndex);
                }
            }

            return 0;
        }

        public long GetDigitPowSum(int pow)
        {
            long digitPowSum = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                int value = GetDigit(i);
                digitPowSum += (long)Math.Pow(value, pow);
            }

            return digitPowSum;
        }

        public long GetDigitFactorialSum()
        {
            int[] factoriels = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            long digitFactorialSum = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                int value = GetDigit(i);
                digitFactorialSum += factoriels[value];
            }

            return digitFactorialSum;
        }

        public void Max(IntegerMap map)
        {
            int autreSize = map.GetSize();
            int thisSize = GetSize();
            if (autreSize < thisSize)
            {
                return;
            }

            if (autreSize == thisSize)
            {
                int index = autreSize - 1;
                while (map.GetDigit(index) == GetDigit(index))
                {
                    index--;
                    if (index < 0)
                    {
                        return;
                    }
                }

                if (map.GetDigit(index) < GetDigit(index))
                {
                    return;
                }
            }

            MultiplyBy(0);
            Add(map);
        }

        public IntegerMap Reverse()
        {
            int size = GetSize();
            IntegerMap map = new IntegerMap();
            for (int i = 0; i < size; i++)
            {
                map.Add(GetDigit(i), size - 1 - i);
            }

            return map;
        }

        public bool Equals(IntegerMap map)
        {
            int max = Math.Max(GetSize(), map.GetSize());
            for (int i = 0; i <= max; i++)
            {
                if (GetDigit(i) != map.GetDigit(i))
                {
                    return false;
                }
            }
            return true;
        }

        public long GetValueSmallestDigits(int nbDigits)
        {
            long value = 0;
            long offset = 1;
            int max = Math.Min(nbDigits, GetSize());
            for (int i = 0; i < max; i++)
            {
                value += offset * GetDigit(i);
                offset *= 10;
            }

            return value;
        }

        public long GetValueGreatestDigits(int nbDigits)
        {
            long value = 0;
            int size = GetSize();
            int min = Math.Max(0, size - nbDigits);
            for (int i = size; i >= min; i--)
            {
                value = 10 * value + GetDigit(i);
            }

            return value;
        }

        private int GetDigit(int index)
        {
            if (!_mapping.ContainsKey(index))
            {
                _mapping[index] = 0;
            }

            return _mapping[index];
        }

        private void SetDigit(int index, int value)
        {
            _mapping[index] = value;
        }
    }
}