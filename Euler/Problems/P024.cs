// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Collections.Generic;
using Euler.Utils;

namespace Euler.Problems
{
    using System;

    public class P024 : AbstractProblem
    {
        public override void DebugProblem()
        {
            int nombreDigit = 3;
            int numero = 4;
            DebugResult(getPermutationNumberOf(numero, nombreDigit), 120);
        }

        public override long ComputeSolution()
        {
            int nombreDigit = 10;
            int numero = 1000000;
            return getPermutationNumberOf(numero, nombreDigit);
        }
		
        private long getPermutationNumberOf(int niemePerm, int digit)
        {
            IntegerMap dictionary = new IntegerMap();
            List<int> chiffres = new List<int>();
            for (int i = 0; i < digit; i++)
            {
                chiffres.Add(i);
            }

            long numberOfPerm = 0;
            for (int index = digit - 1; index >= 0; index--)
            {
                long nombrePossible = Functions.GetPermutationNumber(index);
                int affecte = (int)((niemePerm - 1 - numberOfPerm) / nombrePossible);
                if (affecte >= chiffres.Count)
                {
                    throw new Exception("HORS CHAMP! Max = " + Functions.GetPermutationNumber(digit));
                }

                int chiffre = chiffres[affecte];
                chiffres.Remove(affecte);
                dictionary.Add(chiffre, index);
                numberOfPerm += affecte * nombrePossible;
            }
			
            return dictionary.ToLong();
        }

    }

}