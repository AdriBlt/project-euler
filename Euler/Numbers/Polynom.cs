// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Numbers
{
    using System;
    using System.Collections.Generic;

    /**
     * Polynome à coefficients complexes.
     */
    public class Polynom
    {

        /** Degré du polynome. */
        private int _maxDegree;

        /** Coefficients du polynome. */
        private readonly Dictionary<int, Complex> _coefficients;

        /**
         * Constructeur.
         */
        public Polynom()
        {
            _coefficients = new Dictionary<int, Complex>();
            _maxDegree = 0;
        }

        /**
         * Constructeurs.
         * 
         * @param coefficents
         *            Coefficients (c0->cn)
         */
        public Polynom(Complex[] coefficents) : this()
        {
            int lenght = coefficents.Length;
            for (int i = 0; i < lenght; i++)
            {
                Add(lenght - 1 - i, coefficents[i]);
            }
        }

        /**
         * Constructeurs.
         * 
         * @param coefficents
         *            Coefficients (c0->cn)
         */
        public Polynom(double[] coefficents) : this()
        {
            int lenght = coefficents.Length;
            for (int i = 0; i < lenght; i++)
            {
                Add(lenght - 1 - i, coefficents[i]);
            }
        }

        public Polynom(double a = 0, double b = 0, double c = 0, double d = 0, double e = 0)
            : this(new[] { a, b, c, d, e })
        {
        }

        /**
         * Add (coef * X^index).
         * 
         * @param index
         *            Degré
         * @param coef
         *            Valeur du coef
         */
        public void Add(int index, double coef)
        {
            Add(index, new Complex(coef));
        }

        /**
         * Add (coef * X^index).
         * 
         * @param index
         *            Degré
         * @param coef
         *            Valeur du coef
         */
        public void Add(int index, Complex coef)
        {
            if (coef.IsNul())
            {
                return;
            }

            if (_coefficients.ContainsKey(index))
            {
                Complex newCoef = GetCoefficient(index).Add(coef);
                SetCoefficient(index, newCoef);
            }
            else
            {
                SetCoefficient(index, coef);
            }

            if (index > _maxDegree)
            {
                _maxDegree = index;
            }
            else if (index == _maxDegree)
            {
                UpdateDegre();
            }
        }

        /**
         * Modifie le degré de (X^index).
         * 
         * @param index
         *            Degré
         * @param coef
         *            Valeur du coef
         */
        public void SetCoefficient(int index, double coef)
        {
            SetCoefficient(index, new Complex(coef));
        }

        /**
         * Modifie le degré de (X^index).
         * 
         * @param index
         *            Degré
         * @param coef
         *            Valeur du coef
         */
        public void SetCoefficient(int index, Complex coef)
        {
            _coefficients[index] = coef;
            if (index > _maxDegree && !coef.IsNul())
            {
                _maxDegree = index;
            }
            else if (index == _maxDegree && coef.IsNul())
            {
                UpdateDegre();
            }
        }

        /**
         * Valeur du coef devant (X^deg).
         * 
         * @param deg
         *            Degré
         * @return Coef
         */
        public Complex GetCoefficient(int deg)
        {
            if (_coefficients.ContainsKey(deg))
            {
                return GetCoefficient(deg);
            }
            else
            {
                return new Complex();
            }
        }

        /**
         * Mise é jour du degré.
         */
        private void UpdateDegre()
        {
            while (_maxDegree >= 0)
            {
                if (!GetCoefficient(_maxDegree).IsNul())
                {
                    return;
                }
                _maxDegree--;
            }
        }

        /**
         * Dérive le polynome.
         * 
         * @return Polynome dérivé
         */
        public Polynom Derivate()
        {
            Polynom deriv = new Polynom();
            foreach (int index in _coefficients.Keys)
            {
                if (index == 0)
                {
                    continue;
                }

                Complex coef = GetCoefficient(index).MultiplyByReel(index);
                deriv.Add(index - 1, coef);
            }

            return deriv;
        }

        /**
         * Calcule l'image du point par le polynome.
         * 
         * @param d
         *            Variable
         * @return P(d)
         */
        public Complex Evaluate(double d)
        {
            return Evaluate(new Complex(d));
        }

        /**
         * Calcule l'image du point par le polynome.
         * 
         * @param z
         *            Variable
         * @return P(z)
         */
        public Complex Evaluate(Complex z)
        {
            Complex value = new Complex();
            foreach (int k in _coefficients.Keys)
            {
                Complex nombre = GetCoefficient(k);
                for (int i = 0; i < k; i++)
                {
                    nombre = nombre.MultiplyBy(z);
                }

                value = value.Add(nombre);
            }

            return value;
        }

        public override string ToString()
        {
            if (_maxDegree < 0)
            {
                return "0";
            }

            string str = "";
            bool empty = true;
            for (int i = _maxDegree; i >= 0; i--)
            {
                if (!GetCoefficient(i).IsNul())
                {
                    if (empty)
                    {
                        empty = false;
                    }
                    else
                    {
                        str += " + ";
                    }
                    str += "(" + GetCoefficient(i).ToString() + ")";
                    if (i > 0)
                    {
                        str += " X";
                    }
                    if (i > 1)
                    {
                        str += "^" + i;
                    }
                }
            }
            return str;
        }

        public List<Complex> GetRoots()
        {
            Complex c4 = GetCoefficient(4);
            int degreMax = 4;
            if (_maxDegree > degreMax)
            {
                return null;
            }

            Complex c0 = GetCoefficient(0);
            Complex c1 = GetCoefficient(1);
            Complex c2 = GetCoefficient(2);
            Complex c3 = GetCoefficient(3);
            return GetRoots4(c4, c3, c2, c1, c0);
            // switch (_maxDegree) {
            // case 0:
            // return new List<Complex>();
            // case 1:
            // return GetRoots1(c1, c0);
            // case 2:
            // return GetRoots2(c2, c1, c0);
            // case 3:
            // return GetRoots3(c3, c2, c1, c0);
            // case 4:
            // return GetRoots4(c4, c3, c2, c1, c0);
            // default:
            // return null;
            // }
        }

        /**
         * Calcule les racine du polynome de degré 1.
         * 
         * @param a
         *            Coef de degré 1
         * @param b
         *            Coef de degré 0
         * @return Racine
         */
        public static List<Complex> GetRoots1(Complex a, Complex b)
        {
            List<Complex> roots = new List<Complex>(1);
            if (a.IsNul())
            {
                return roots;
            }

            roots.Add(b.MultiplyByReel(-1).DivideBy(a));
            return roots;
        }

        /**
         * Calcule les racine du polynome de degré 2.
         * 
         * @param a
         *            Coef de degré 2
         * @param b
         *            Coef de degré 1
         * @param c
         *            Coef de degré 0
         * @return Racines
         */
        public static List<Complex> GetRoots2(Complex a, Complex b, Complex c)
        {
            if (a.IsNul())
            {
                return GetRoots1(b, c);
            }

            List<Complex> roots = new List<Complex>(2);
            Complex delta = Complex.GetSum(new[] { b.GetSquare(), Complex.GetProduct(-4, new[] { a, c }) });
            roots.Add(b.Add(delta.GetSquareRoot()).DivideBy(a).MultiplyByReel(-1.0 / 2));
            roots.Add(b.Minus(delta.GetSquareRoot()).DivideBy(a).MultiplyByReel(-1.0 / 2));
            return roots;
        }

        /**
         * Calcule les racine du polynome de degré 3.
         * 
         * @param a
         *            Coef de degré 3
         * @param b
         *            Coef de degré 2
         * @param c
         *            Coef de degré 1
         * @param d
         *            Coef de degré 0
         * @return Racines
         */
        public static List<Complex> GetRoots3(Complex a, Complex b, Complex c, Complex d)
        {
            if (a.IsNul())
            {
                return GetRoots2(b, c, d);
            }

            List<Complex> roots = new List<Complex>(3);
            Complex p = Complex.GetSum(new[]{
                c.DivideBy(a),
                b.GetSquare().DivideBy(a.GetSquare()).MultiplyByReel(-1.0 / 3.0)
            });
            Complex q = Complex.GetSum(new[] {
                d.DivideBy(a),
                b.MultiplyBy(c).DivideBy(a.GetSquare()).MultiplyByReel(-1.0 / 3.0), b.GetCube().DivideBy(a.GetCube()).MultiplyByReel(2.0 / 27.0)
            });
            List<Complex> cardan = GetRoots2(new Complex(1), q, p.GetCube().MultiplyByReel(-1.0 / 27.0));
            Complex chVar = b.DivideBy(a).MultiplyByReel(-1.0 / 3.0);
            Complex root = Complex.GetSum(new[] {
                chVar,
                cardan[0].GetCubeRoot(),
                cardan[1].GetCubeRoot()
            });
            roots.Add(root);
            Complex bb = b.Add(a.MultiplyBy(root));
            Complex cc = c.Add(bb.MultiplyBy(root));
            roots.AddRange(GetRoots2(a, bb, cc));
            return roots;
        }

        /**
         * Calcule les racine du polynome de degré 4.
         * 
         * @param a
         *            Coef de degré 4
         * @param b
         *            Coef de degré 3
         * @param c
         *            Coef de degré 2
         * @param d
         *            Coef de degré 1
         * @param e
         *            Coef de degré 0
         * @return Racines
         */
        public static List<Complex> GetRoots4(Complex a, Complex b, Complex c, Complex d, Complex e)
        {
            if (a.IsNul())
            {
                return GetRoots3(b, c, d, e);
            }

            List<Complex> roots = new List<Complex>(4);
            Complex p = Complex.GetSum(new[] {
                c.DivideBy(a),
                b.GetSquare().DivideBy(a.GetSquare()).MultiplyByReel(-3.0 / 8)
            });
            Complex q = Complex.GetSum(new[] {
                d.DivideBy(a),
                b.MultiplyBy(c).DivideBy(a.GetSquare()).MultiplyByReel(-1.0 / 2),
                b.GetCube().DivideBy(a.GetCube()).MultiplyByReel(1.0 / 8)
            });
            Complex r = Complex.GetSum(new[] {
                e.DivideBy(a),
                b.MultiplyBy(d).DivideBy(a.GetSquare()).MultiplyByReel(-1.0 / 4),
                b.GetSquare().MultiplyBy(c).DivideBy(a.GetCube()).MultiplyByReel(1.0 / 16),
                b.GetSquare().DivideBy(a.GetSquare()).GetCube().MultiplyByReel(-3.0 / 256)
            });
            List<Complex> ferrari = GetRoots3(
                new Complex(8),
                p.MultiplyByReel(-4),
                r.MultiplyByReel(-8),
                r.MultiplyBy(p).MultiplyByReel(4).Minus(q.GetSquare()));
            Complex root = ferrari[0];
            Complex aa = root.MultiplyByReel(2).Minus(p).GetSquareRoot();
            Complex bb = aa.IsNul()
                ? root.GetSquare().Minus(r).GetSquareRoot()
                : q.DivideBy(aa).MultiplyByReel(-1.0 / 2);
            roots.AddRange(GetRoots2(new Complex(1), aa, root.Add(bb)));
            roots.AddRange(GetRoots2(new Complex(1), aa.MultiplyByReel(-1), root.Minus(bb)));
            return roots;
        }


        public static void Test()
        {
            // PrintPolynomAndRoots(new Polynom(2, 5));
            // Console.WriteLine();
            // PrintPolynomAndRoots(new Polynom(1, 0, 25));
            // Console.WriteLine();
            // PrintPolynomAndRoots(new Polynom(1, 0, 0, -1));
            // Console.WriteLine();
            // PrintPolynomAndRoots(new Polynom(1, -6, 11, -6));
            // Console.WriteLine();
            PrintPolynomAndRoots(new Polynom(1, 2, 1, 1));
            Console.WriteLine();
            PrintPolynomAndRoots(new Polynom(1, 10, 0, 0));
        }

        private static void PrintPolynomAndRoots(Polynom p)
        {
            Console.WriteLine(p);
            foreach (Complex root in p.GetRoots())
            {
                Console.WriteLine("p(" + root + ") = " + p.Evaluate(root) + "\t(module = " + p.Evaluate(root).GetModule() + ")");
            }
        }

    }
}
