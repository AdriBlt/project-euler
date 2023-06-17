// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Numbers
{
    using System;
    using Euler.Utils;

    /** */
    public class Fraction
    {
        /** */
        private int _numerator;
        /** */
        private int _denominator;

        /** */
        public Fraction() : this(0)
        {
        }

        /**
         * 
         * @param x
         *            entier
         */
        public Fraction(int x) : this(x, 1)
        {
        }

        /**
         * 
         * @param a
         *            numerator
         * @param b
         *            denominator
         */
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }

            _numerator = numerator;
            _denominator = denominator;
        }

        /**
         * 
         */
        public void Simplify()
        {
            int pgcd = Fraction.GetGreatestCommonDivisor(
                Math.Abs(_numerator),
                Math.Abs(_denominator));
            _numerator /= pgcd;
            _denominator /= pgcd;
            if (_denominator < 0)
            {
                _numerator *= -1;
                _denominator *= -1;
            }
        }

        /**
         * 
         * @param a
         *            entier
         * @param b
         *            entier
         * @return pgcd(a,b)
         */
        private static int GetGreatestCommonDivisor(int a, int b)
        {
            return Functions.GetGreatestCommonDivisor(a, b);
        }

        /**
         * 
         * @param a
         *            entier
         * @param b
         *            entier
         * @return ppcm(a,b)
         */
        private static int GetLeastCommonMultiple(int a, int b)
        {
            return Functions.GetLeastCommonMultiple(a, b);
        }

        /**
         * 
         * @param frac1
         *            Fraction
         * @param frac2
         *            Fraction
         * @return frac1 + frac2
         */
        public Fraction Add(Fraction frac)
        {
            Simplify();
            frac.Simplify();
            int nextD = Fraction.GetLeastCommonMultiple(_denominator, frac._denominator);
            int c1 = nextD / _denominator;
            int c2 = nextD / frac._denominator;
            int n1 = _numerator * c1;
            int n2 = frac._numerator * c2;
            int nextN = n1 + n2;
            Fraction frac3 = new Fraction(nextN, nextD);
            frac3.Simplify();
            return frac3;
        }

        /**
         * 
         * @param frac1
         *            Fraction
         * @param frac2
         *            Fraction
         * @return frac1 - frac2
         */
        public Fraction Minus(Fraction frac)
        {
            Simplify();
            frac.Simplify();
            int nextD = Fraction.GetLeastCommonMultiple(_denominator, frac._denominator);
            int c1 = nextD / _denominator;
            int c2 = nextD / frac._denominator;
            int n1 = _numerator * c1;
            int n2 = frac._numerator * c2;
            int nextN = n1 - n2;
            Fraction frac3 = new Fraction(nextN, nextD);
            frac3.Simplify();
            return frac3;
        }

        /**
         * 
         * @param frac1
         *            Fraction
         * @param frac2
         *            Fraction
         * @return frac1 * frac2
         */
        public Fraction MultiplyBy(Fraction frac)
        {
            Simplify();
            frac.Simplify();
            int nextN = _numerator * frac._numerator;
            int nextD = _denominator * frac._denominator;
            Fraction frac3 = new Fraction(nextN, nextD);
            frac3.Simplify();
            return frac3;
        }

        /**
         * 
         * @param frac1
         *            Fraction
         * @param frac2
         *            Fraction
         * @return frac1 / frac2
         */
        public Fraction DivideBy(Fraction frac)
        {
            Simplify();
            frac.Simplify();
            int nextN = _numerator * frac._denominator;
            int nextD = _denominator * frac._numerator;
            Fraction frac3 = new Fraction(nextN, nextD);
            frac3.Simplify();
            return frac3;
        }

        /**
         * 
         * @param fracs
         *            Fractions
         * @return sum fracs
         */
        public static Fraction Add(Fraction[] fracs)
        {
            Fraction add = new Fraction();
            foreach (Fraction frac in fracs)
            {
                add = add.Add(frac);
            }

            return add;
        }

        /**
         * 
         * @param fracs
         *            Fractions
         * @return sum fracs
         */
        public static Fraction Multiply(params Fraction[] fracs)
        {
            Fraction mul = new Fraction(1);
            foreach (Fraction frac in fracs)
            {
                mul = mul.MultiplyBy(frac);
            }
            return mul;
        }

        /**
         * 
         * @param frac
         *            Fraction
         * @return 1 / frac
         */
        public Fraction Invert()
        {
            return new Fraction(_denominator, _numerator);
        }

        /**
         * @return valeur.
         */
        public double GetDoubleValue()
        {
            if (_denominator == 0)
            {
                return double.NaN;
            }

            return 1.0 * _numerator / _denominator;
        }

        public int GetNumerator()
        {
            return _numerator;
        }

        public int GetDenominator()
        {
            return _denominator;
        }

        public override string ToString()
        {
            if (_denominator == 1)
            {
                return _numerator.ToString();
            }
            return _numerator + "/" + _denominator;
        }

        public static void Test()
        {
            // Fraction p = plus(new Fraction(4, 3), new Fraction(-8, 3),
            // new Fraction(3, 4));
            // Fraction q = plus(new Fraction(-8, 27), new Fraction(8, 9),
            // new Fraction(-1, 2), new Fraction(-3, 8));
            Fraction p = new Fraction(13, 9);
            Fraction q = new Fraction(25, 27);
            Console.WriteLine("(p,q) = (" + p + "," + q + ")");
            Fraction coef = new Fraction(4, 27);
            Fraction delta = q.MultiplyBy(q).Add(Fraction.Multiply(new[] { coef, p, p, p }));
            Console.WriteLine("delta = " + delta);
            double valPos = (-q.GetDoubleValue() + Math.Sqrt(delta.GetDoubleValue())) / 2;
            double valNeg = (-q.GetDoubleValue() - Math.Sqrt(delta.GetDoubleValue())) / 2;
            Fraction chtVar = new Fraction(2, 3);
            double r = Complex.GetCubeRoot(valPos) + Complex.GetCubeRoot(valNeg) - chtVar.GetDoubleValue();
            Console.WriteLine("r = " + r);
            Console.WriteLine("P(r) = " + (r * r * r + 2 * r * r + r + 1));
        }
    }
}
