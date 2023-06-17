// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BigIntegerMap : IComparable<BigIntegerMap>
    {

        private const int ValPalier = 1000000; // int.MAX_VALUE;

        private readonly Dictionary<int, int> _mapping;

        public BigIntegerMap()
        {
            this._mapping = new Dictionary<int, int> { [0] = 0 };
        }

        public BigIntegerMap(int val) : this()
        {
            this.Add(val);
        }

        public BigIntegerMap(BigIntegerMap m) : this()
        {
            this.Add(m);
        }

        private int GetIndex(int index)
        {
            if (!this._mapping.ContainsKey(index))
            {
                this._mapping[index] = 0;
            }

            return this._mapping[index];
        }

        private void SetIndex(int index, int value)
        {
            this._mapping[index] = value;
        }

        public void Add(int i)
        {
            int ajout = i;
            int index = 0;
            while (ajout > 0)
            {
                int value = ajout % ValPalier;
                ajout = ajout / ValPalier + this.Add(value, index);
                index++;
            }
        }

        private int Add(int value, int index) {
            int somme = value + this.GetIndex(index);
            this.SetIndex(index, somme % ValPalier);
            return somme / ValPalier;
        }

        public void Multiply(int mult)
        {
            int i;
            for (i = 0; i < this._mapping.Count; i++)
            {
                int val = mult * this.GetIndex(i);
                this.SetIndex(i, val);
            }

            int retenue = 0;
            for (i = 0; i < this._mapping.Count; i++)
            {
                int val = retenue + this.GetIndex(i);
                this.SetIndex(i, val % ValPalier);
                retenue = val / ValPalier;
            }

            while (retenue > 0)
            {
                this.SetIndex(i, retenue % ValPalier);
                retenue = retenue / ValPalier;
                i++;
            }
        }

        public void Divide(int div)
        {
            int reste = 0;
            for (int i = this._mapping.Count - 1; i >= 0; i--)
            {
                int val = reste * ValPalier + this.GetIndex(i);
                this.SetIndex(i, val / div);
                reste = val % div;
            }
        }

        private int GetMaxIndex()
        {
            int maxIndex = _mapping.Keys.Max();
            while (maxIndex > 0 && this.GetIndex(maxIndex) == 0)
            {
                maxIndex--;
            }

            return maxIndex;
        }

        public override string ToString()
        {
            string output = "";
            int size = ValPalier.ToString().Length - 1;
            int maxIndex = this.GetMaxIndex();
            for (int i = 0; i < maxIndex; i++)
            {
                string ajout = this.GetIndex(i).ToString();
                while (ajout.Length < size)
                {
                    ajout += "0";
                }

                output = ajout + output;
            }

            return this.GetIndex(maxIndex).ToString() + output;
        }

        public void Add(BigIntegerMap map)
        {
            int i;
            int retenue = 0;
            for (i = 0; i < map._mapping.Count; i++)
            {
                int val = this.GetIndex(i) + map.GetIndex(i) + retenue;
                this.SetIndex(i, val % ValPalier);
                retenue = val / ValPalier;
            }
            while (retenue > 0)
            {
                this.SetIndex(i, retenue % ValPalier);
                retenue = retenue / ValPalier;
                i++;
            }
        }

        public int CompareTo(BigIntegerMap other)
        {
            int index = this.GetMaxIndex();
            int delta = index - other.GetMaxIndex();
            if (delta != 0)
            {
                return delta;
            }
            while (index >= 0)
            {
                delta = this.GetIndex(index) - other.GetIndex(index);
                if (delta != 0)
                {
                    return delta;
                }

                index--;
            }
            return 0;
        }

        public bool IsNull()
        {
            return this.GetMaxIndex() == 0 && this.GetIndex(0) == 0;
        }

        public int GetDigitSize()
        {
            int index = 0;
            int number = 0;
            while (this.GetIndex(index) > 0)
            {
                number += (int)Math.Ceiling(Math.Log10(this.GetIndex(index)));
                index++;
            }

            return number;
        }

        public int GetDigit(int index)
        {
            int i = 0;
            int number = 0;
            while (this.GetIndex(i) > 0)
            {
                int delta = (int)Math.Ceiling(Math.Log10(this.GetIndex(i)));
                if (number + delta > index)
                {
                    int pos = index - number;
                    int val = this.GetIndex(i);
                    return (int)(val / Math.Pow(10, pos) % 10);
                }
                number += delta;
                i++;
            }
            return 0;
        }

        public static void Test()
        {
            BigIntegerMap m = new BigIntegerMap(99999999);
            Console.WriteLine(m);
            m.Add(1);
            Console.WriteLine(m);
            m.Divide(3);
            Console.WriteLine(m);

            BigIntegerMap m2 = new BigIntegerMap(1234567890);
            Console.WriteLine(m2);
            Console.WriteLine(m2.GetDigitSize());
            Console.WriteLine(m2.GetDigit(4));
            Console.WriteLine(m2.GetDigit(5));
        }
    }
}
