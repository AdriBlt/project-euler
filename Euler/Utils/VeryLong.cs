// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;

    public class VeryLong
    {
        private readonly long _value;

        private readonly int _exp;

        public VeryLong(long v, int e)
        {
            _value = v;
            _exp = e;
        }

        public long GetRoot()
        {
            if (_exp % 2 == 1)
            {
                return (long)(Math.Sqrt(10 * _value) * Math.Pow(10, (int) ((_exp - 1) / 2)));
            }
            else
            {
                return (long)(Math.Sqrt(_value) * Math.Pow(10, (int) (_exp / 2)));
            }
        }

        public long GetNumber()
        {
            return (long)(_value * Math.Pow(10, _exp));
        }


        public override string ToString()
        {
            string output = _value.ToString();
            for (int i = 0; i < _exp; i++)
            {
                output += "0";
            }

            return output;
        }
    }
}