// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Functions
    {
        public static bool IsPrime(this long number)
        {
            if (number < 2)
            {
                return false;
            }

            long root = (long)Math.Sqrt(number);
            for (int i = 2; i <= root; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPalindrome(this long number) => IsPalindrome(number.ToString());

        public static bool IsPalindrome(string number)
        {
            string[] digits = number.Select(c => c.ToString()).ToArray();
            int size = digits.Length;
            for (int i = 0; i <= size / 2; i++)
            {
                if (digits[i] != digits[size - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDigitProduct(this long nombre, int nDigit)
        {
            long maxDigit = (long)Math.Pow(10, nDigit);
            for (int i = 1; i < maxDigit; i++)
            {
                if (nombre % i == 0)
                {
                    long j = nombre / i;
                    if (j < maxDigit)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public static long GetBinomialCoeff(long k, long n)
        {
            if (n < k || k < 0)
            {
                return 0;
            }

            Queue<long> multi = new Queue<long>();
            for (long i = n; i > n - k; i--)
            {
                multi.Enqueue(i);
            }

            HashSet<long> divis = new HashSet<long>();
            for (long i = k; i > 1; i--)
            {
                divis.Add(i);
            }

            long nombre = 1;
            while (divis.Count > 0)
            {
                long nextDiv = -1;
                foreach (long i in divis)
                {
                    if (nombre % i == 0)
                    {
                        nextDiv = i;
                        break;
                    }
                }

                if (nextDiv > 0)
                {
                    divis.Remove(nextDiv);
                    nombre = nombre / nextDiv;
                    continue;
                }

                if (multi.Count > 0)
                {
                    long nextMult = multi.Dequeue();
                    nombre *= nextMult;
                }
                else
                {
                    throw new Exception();
                }
            }

            foreach (long i in multi)
            {
                nombre *= i;
            }

            return nombre;
        }

        public static long GetFactorielDigitSum(this long nombre)
        {
            IntegerMap map = new IntegerMap(1);
            for (int i = 2; i <= nombre; i++)
            {
                map.MultiplyBy(i);
            }

            return map.GetDigitSum();
        }

        public static long GetDivisorsSum(long number)
        {
            long somme = 1;
            if (number == 1)
            {
                return somme;
            }

            long root = (long)Math.Sqrt(number);
            for (long i = 2; i <= root; i++)
            {
                if (number % i == 0)
                {
                    somme += i + number / i;
                }
            }

            if ((long)Math.Pow(root, 2) == number)
            {
                somme -= root;
            }

            return somme;
        }

        public static long Factorial(this long nombre)
        {
            long factoriel = 1;
            for (long i = 2; i <= nombre; i++)
            {
                factoriel *= i;
            }

            return factoriel;
        }

        public static long GetPermutationNumber(long nombre) => nombre.Factorial();

        public static int IsPandigital(string number)
        {
            bool[] tab = new bool[10];
            tab[0] = true;
            for (int i = 1; i < 10; i++)
            {
                tab[i] = false;
            }

            foreach (char c in number)
            {
                int i = int.Parse(c.ToString());
                if (tab[i])
                {
                    return -1;
                }

                tab[i] = true;
            }

            for (int i = 0; i < 10; i++)
            {
                if (!tab[i])
                {
                    return 0;
                }
            }

            return 1;
        }

        public static bool IsPandigitalStrict(this long val) => IsPandigitalStrict(val.ToString());

        private static bool IsPandigitalStrict(string number)
        {
            int size = number.Length;
            bool[] tab = new bool[10];
            tab[0] = true;
            for (int i = 1; i <= size; i++)
            {
                tab[i] = false;
            }

            for (int i = size + 1; i < 10; i++)
            {
                tab[i] = true;
            }

            foreach (char c in number)
            {
                int i = int.Parse(c.ToString());
                if (tab[i])
                {
                    return false;
                }

                tab[i] = true;
            }

            for (int i = 0; i < 10; i++)
            {
                if (!tab[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static List<long> GetPrimesUnder(long max)
        {
            List<long> primes = new List<long>();
            for (long i = 2; i <= max; i++)
            {
                long root = (long)Math.Sqrt(i);
                bool isPrime = true;
                foreach (long prime in primes)
                {
                    if (prime > root)
                    {
                        break;
                    }

                    if (i % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public static string ToBinary(long entier)
        {
            long nombre = entier;
            IntegerMap map = new IntegerMap();
            int index = 0;
            while (nombre > 0)
            {
                if (nombre % 2 == 1)
                {
                    map.Add(1, index);
                }
                index++;
                nombre /= 2;
            }

            return map.ToString();
        }

        public static int GetDigitNumber(long number)
        {
            if (number <= 0)
            {
                return 0;
            }

            // TODO : ToString().Count ?
            // TODO : while > 0 divide by 10
            return 1 + (int)Math.Floor(Math.Log10(number));
        }

        public static int GetGreatestCommonDivisor(int i, int j)
        {
			/*
				if (j == 0)
				{
					return i;
				}

				if (i == 0)
				{
					return j;
				}

				return GetGreatestCommonDivisor(j, i % j);
			*/

            int a = Math.Max(i, j);
            int b = Math.Min(i, j);
            while (b > 0)
            {
                int c = a;
                a = b;
                b = c % b;
            }

            return a;
        }

        public static int GetLeastCommonMultiple(int i, int j)
        {
            return i * j / GetGreatestCommonDivisor(i, j);
        }

        public static int Reverse(int nombre)
        {
            int start = nombre;
            int end = 0;
            while (start > 0)
            {
                end = 10 * end + start % 10;
                start = start / 10;
            }

            return end;
        }

        public static bool IsTriangleNumber(long val)
        {
            double root = 1.0 * (Math.Sqrt(1 + 8 * val) - 1) / 2;
            return root % 1 == 0;
        }

        public static bool IsPentagonal(long val)
        {
            double root = 1.0 * (1 + Math.Sqrt(1 + 24 * val)) / 6;
            return root % 1 == 0;
        }

        public static bool IsHexagonal(long val)
        {
            double root = 1.0 * (1 + Math.Sqrt(1 + 8 * val)) / 4;
            return root % 1 == 0;
        }

        public static int GetPrimeDivisorCount(long number, List<long> primes)
        {
            int count = 0;
            double root = Math.Sqrt(number);
            foreach (long p in primes)
            {
                if (number % p == 0)
                {
                    count++;
                }

                if (p > root)
                {
                    break;
                }
            }

            return count;
        }
    }
}
