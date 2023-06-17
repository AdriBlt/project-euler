// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Numbers
{
    using System;

    /**
     * Nombre complexe.
     * 
     */
    public class Complex : IEquatable<Complex>
    {
        private const double Tolerance = 0.000001;
        public static readonly Complex Null = new Complex();
        public static readonly Complex U = new Complex(1);
        public static readonly Complex I = new Complex(0, 1);

        /** Partie réelle. */
        private double _x;

        /** Partie imaginaire. */
        private double _y;

        /**
         * Constructeur nul.
         */
        public Complex() : this(0)
        {
        }

        /**
         * Constructeur réel.
         * 
         * @param re
         *            Partie réelle
         */
        public Complex(double re) : this(re, 0)
        {
        }

        /**
         * Constructeur.
         * 
         * @param re
         *            Partie réelle
         * @param im
         *            Partie imaginaire
         */
        public Complex(double re, double im)
        {
            this.SetRealPart(re);
            this.SetImaginaryPart(im);
        }

        /**
         * @return Partie réelle.
         */
        public double GetRealPart()
        {
            return this._x;
        }

        /**
         * @param re
         *            Partie réelle
         */
        public void SetRealPart(double re)
        {
            this._x = re;
        }

        /**
         * @return Partie imaginaire.
         */
        public double GetImaginaryPart()
        {
            return this._y;
        }

        /**
         * @param im
         *            Partie imaginaire
         */
        public void SetImaginaryPart(double im)
        {
            this._y = im;
        }

        /**
         * @return Module au carré
         */
        public double GetSquareModule()
        {
            return Math.Pow(this.GetRealPart(), 2) + Math.Pow(this.GetImaginaryPart(), 2);
        }

        /**
         * @return Module
         */
        public double GetModule()
        {
            return Math.Sqrt(this.GetSquareModule());
        }

        /**
         * @param d
         *            réel
         * @return this + d
         */
        public Complex AddReal(double d)
        {
            return new Complex(this.GetRealPart() + d, this.GetImaginaryPart());
        }

        /**
         * @param d
         *            réel
         * @return this + i d
         */
        public Complex AddImaginary(double d)
        {
            return new Complex(this.GetRealPart(), this.GetImaginaryPart() + d);
        }

        /**
         * @param c
         *            Complexe
         * @return this + c
         */
        public Complex Add(Complex c)
        {
            return new Complex(this.GetRealPart() + c.GetRealPart(), this.GetImaginaryPart() + c.GetImaginaryPart());
        }

        /**
         * @param c
         *            Complexe
         * @return this - c
         */
        public Complex Minus(Complex c)
        {
            return new Complex(this.GetRealPart() - c.GetRealPart(), this.GetImaginaryPart() - c.GetImaginaryPart());
        }

        /**
         * @param c
         *            Complexe
         * @return this * c
         */
        public Complex MultiplyBy(Complex c)
        {
            return new Complex(
                this.GetRealPart() * c.GetRealPart() - this.GetImaginaryPart() * c.GetImaginaryPart(),
                this.GetImaginaryPart() * c.GetRealPart() + c.GetImaginaryPart() * this.GetRealPart());
        }

        /**
         * @return this^2
         */
        public Complex GetSquare()
        {
            return new Complex(
                this.GetRealPart() * this.GetRealPart() - this.GetImaginaryPart() * this.GetImaginaryPart(),
                2 * this.GetImaginaryPart() * this.GetRealPart());
        }

        /**
         * @return Racine cubique.
         */
        public Complex GetSquareRoot()
        {
            double module = this.GetModule();
            return new Complex(
                Math.Sqrt((module + this.GetRealPart()) / 2),
                Math.Sqrt((module - this.GetRealPart()) / 2));
        }

        /**
         * @return this^3
         */
        public Complex GetCube()
        {
            return new Complex(
                this._x * this._x * this._x - 3 * this._x * this._y * this._y,
                3 * this._x * this._x * this._y - this._y * this._y * this._y);
        }

        /**
         * @return Racine cubique
         */
        public Complex GetCubeRoot()
        {
            if (IsReal())
            {
                return new Complex(GetCubeRoot(this.GetRealPart()));
            }

            if (this.IsImaginary())
            {
                return new Complex(0, -GetCubeRoot(this.GetImaginaryPart()));
            }

            double module = this.GetModule();
            double theta = this.GetAngle();
            double re = GetCubeRoot(module) * Math.Cos(theta / 3);
            double im = GetCubeRoot(module) * Math.Sin(theta / 3);
            return new Complex(re, im);
        }

        public static double GetCubeRoot(double value)
        {
            // return Math.Cbrt(value);
            return Math.Pow(value, 1.0 / 3);
        }

        /**
         * @param puiss
         *            Puissance
         * @return this^puiss
         */
        public Complex GetPow(double puiss)
        {
            double module = this.GetModule();
            double theta = this.GetAngle();
            double re = Math.Pow(module, puiss) * Math.Cos(theta * puiss);
            double im = Math.Pow(module, puiss) * Math.Sin(theta * puiss);
            return new Complex(re, im);
        }

        /**
         * z = x + i y = r exp(ia).
         * 
         * @return a
         */
        public double GetAngle()
        {
            return Math.Atan2(this._y, this._x);
        }

        /**
         * @param c
         *            Complexe2 != 0
         * @return this/c
         */
        public Complex DivideBy(Complex c)
        {
            double denum = c.GetSquareModule();
            if (Math.Abs(denum) < Tolerance)
            {
                throw new DivideByZeroException();
            }

            return new Complex(
                (this.GetRealPart() * c.GetRealPart() + this.GetImaginaryPart() * c.GetImaginaryPart()) / denum,
                (this.GetRealPart() * c.GetImaginaryPart() - this.GetImaginaryPart() * c.GetRealPart()) / denum);
        }

        /**
         * @param c
         *            Complexe2
         * @return Distance entre les deux complexes
         */
        public double GetSquareDistanceFrom(Complex c)
        {
            return Math.Pow(this.GetRealPart() - c.GetRealPart(), 2)
                   + Math.Pow(this.GetImaginaryPart() - c.GetImaginaryPart(), 2);
        }

        /**
         * @return Est nul
         */
        public bool IsNul()
        {
            return this.IsReal() && this.IsImaginary();
        }

        /**
         * @param c
         *            Complexe2
         * @return Complexe == Complexe2
         */
        public bool Equals(Complex other)
        {
            if (other == null)
            {
                return false;
            }

            return Math.Abs(this.GetRealPart() - other.GetRealPart()) < Tolerance 
                && Math.Abs(this.GetImaginaryPart() - other.GetImaginaryPart()) < Tolerance;
        }

        /**
         * @param d
         *            Réel
         * @return d * Complexe
         */
        public Complex MultiplyByReel(double d)
        {
            return new Complex(d * this.GetRealPart(), d * this.GetImaginaryPart());
        }

        /**
         * @return N'est pas complexe
         */
        public bool IsNan()
        {
            return double.IsNaN(this.GetRealPart()) || Double.IsNaN(this.GetImaginaryPart());
        }

        /**
         * @return Est réel
         */
        public bool IsReal()
        {
            return Math.Abs(this.GetImaginaryPart()) < Tolerance;
        }

        /**
         * @return Est imaginaire pur
         */
        public bool IsImaginary()
        {
            return Math.Abs(this.GetRealPart()) < Tolerance;
        }
        

        public override string ToString()
        {
            Object re = this.GetRealPart();
            Object im = this.GetImaginaryPart();
            if (Math.Abs(this.GetRealPart() % 1) < Tolerance)
            {
                re = (int)this.GetRealPart();
            }

            if (Math.Abs(this.GetImaginaryPart() % 1) < Tolerance)
            {
                im = (int)this.GetImaginaryPart();
            }

            if (this.IsReal())
            {
                return re.ToString();
            }

            if (this.IsImaginary())
            {
                return "i " + im.ToString();
            }

            return re.ToString() + " + i " + im.ToString();
        }

        public Complex Clone()
        {
            return new Complex(this._x, this._y);
        }

        /**
         * Somme.
         * 
         * @param coef
         *            Réel
         * @param complexes
         *            Complexes
         * @return sum(complexes)
         */
        public static Complex GetSum(double constante, Complex[] complexes)
        {
            Complex sum = new Complex(constante);
            foreach (Complex c in complexes)
            {
                sum = sum.Add(c);
            }

            return sum;
        }

        /**
         * Somme.
         * 
         * @param complexes
         *            Complexes
         * @return sum(complexes)
         */
        public static Complex GetSum(Complex[] complexes)
        {
            return GetSum(0, complexes);
        }

        /**
         * Produit.
         * 
         * @param coef
         *            Réel
         * @param complexes
         *            Complexes
         * @return sum(complexes)
         */
        public static Complex GetProduct(double coef, Complex[] complexes)
        {
            Complex product = new Complex(coef);
            foreach (Complex c in complexes)
            {
                product = product.MultiplyBy(c);
            }

            return product;
        }

        /**
         * Produit.
         * 
         * @param complexes
         *            Complexes
         * @return sum(complexes)
         */
        public static Complex GetProduct(Complex[] complexes)
        {
            return GetProduct(1, complexes);
        }
        
        public static void Test()
        {
            Complex a = new Complex(2, 3);
            Console.WriteLine(a);
            Complex b = new Complex(2, -3);
            Console.WriteLine(b);
            Complex c = a.GetCubeRoot();
            Console.WriteLine(c);
            Complex d = b.GetCubeRoot();
            Console.WriteLine(d);
            Complex e = c.Add(d);
            Console.WriteLine(e);
        }

    }
}
