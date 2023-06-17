// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;

    public class EulerSum
    {
        private readonly long _size;

        private readonly int[][] _sums;

        private readonly int _sizeMax;

        public EulerSum(int n)
        {
            _size = n;
            _sizeMax = n / 500;
            _sums = new int[_sizeMax - 1][];
            for (int x = 2; x <= _sizeMax; x++)
            {
                _sums[x - 2] = new int[x - 1];
                for (int y = 2; y <= x; y++)
                {
                    Set(x, y, -1);
                }
            }
        }

        private bool IsInArray(int x, int y) {
            return 2 <= y && y <= x && x <= _sizeMax;
        }

        private int Get(int x, int y) {
            if (!IsInArray(x, y))
            {
                return -1;
            }

            return _sums[x - 2][y - 2];
        }

        private void Set(int x, int y, int i) {
            if (!IsInArray(x, y))
            {
                return;
            }

            _sums[x - 2][y - 2] = i;
        }

        public string GetSommeEulerStep()
        {
            long step = 0;
            for (int x = 1; x <= _size; x++)
            {
                Console.WriteLine(x + " / " + _size);
                for (int y = 1; y <= _size; y++)
                {
                    step += GetNumberEulerStep(x, y);
                }
            }

            return step.ToString();
        }

        public string GetSommeEulerStepBySteps()
        {
            int steps = 50000;
            int nbSteps = (int)(_size / steps);
            Console.WriteLine("NB = " + nbSteps);
            for (int s = 0; s < nbSteps; s++)
            {
                long sortie = 0;
                for (int x = 1; x <= steps; x++)
                {
                    for (int y = 1; y <= _size; y++)
                    {
                        int val = s * steps + x;
                        sortie += GetNumberEulerStep(val, y);
                    }
                }
                Console.WriteLine(s + " : " + sortie);
            }

            return "Add above (" + nbSteps + ")";
        }

        private int GetNumberEulerStep(int x0, int y0) {
            if (y0 == 0)
            {
                return 0;
            }

            if (y0 == 1)
            {
                return 1;
            }

            if (IsInArray(x0, y0))
            {
                int val = Get(x0, y0);
                if (val >= 0)
                {
                    return val;
                }
            }

            int x = x0 % y0;
            if (x == 0)
            {
                if (IsInArray(x0, y0))
                {
                    Set(x0, y0, 1);
                }

                return 1;
            }

            int y = y0 % x;
            int sortie = 2 + GetNumberEulerStep(x, y);
            if (IsInArray(x0, y0))
            {
                Set(x0, y0, sortie);
            }

            return sortie;
        }

    }
}
