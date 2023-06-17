// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Collections.Generic;
    using Euler.Utils;

    public class P434: AbstractProblem
    {
        public override void DebugProblem()
        {
            // DebugResult(, );
			// Console.WriteLine(new P434(2, 3).getNombreConfig());
			// Console.WriteLine(new P434(5, 5).getNombreConfig());
			// Console.WriteLine(getSommeConfig(5));
        }

        public override long ComputeSolution()
        {
			return getSommeConfig(100);
		}

		private int n;
		private int m;
		private int max;
		private bool[] tab;
		private bool[] etat;

		public P434(int nSize, int mSize) {
			this.n = nSize;
			this.m = mSize;
			this.max = this.n * this.m;
			this.tab = new bool[this.max];
			for (int k = 0; k < this.max; k++) {
				this.tab[k] = false;
			}
			this.etat = new bool[this.max];
		}

		public int getNombreConfig() {
			int somme = 0;
			do {
				this.getNewEtat();
				if (this.isGoodConfig()) {
					somme++;
				}
			} while (this.getNext());
			return somme;
		}

		private void getNewEtat() {
			for (int k = 0; k < this.max; k++) {
				this.etat[k] = this.tab[k];
			}
		}

		private bool isGoodConfig() {
			bool hasChanged;
			do {
				hasChanged = false;
				for (int k = 0; k < this.max; k++) {
					if (!this.etat[k]) {
						if (this.hasConer(k)) {
							this.etat[k] = true;
							hasChanged = true;
						}
					}
				}
			} while (hasChanged);
			for (int k = 0; k < this.max; k++) {
				if (!this.etat[k]) {
					return false;
				}
			}
			return true;
		}

		private bool hasConer(int index) {
			int i = index / this.m;
			int j = index % this.m;
			for (int ii = 0; ii < this.n; ii++) {
				for (int jj = 0; jj < this.m; jj++) {
					if (this.etat[this.m * ii + j] & this.etat[this.m * i + jj]
							& this.etat[this.m * ii + jj]) {
						return true;
					}
				}
			}
			return false;
		}

		private bool getNext() {
			int index = 0;
			while (this.tab[index]) {
				this.tab[index] = false;
				index++;
				if (index == this.max) {
					return false;
				}
			}
			this.tab[index] = true;
			return true;

		}

		private static long getSommeConfig(int taille) {
			long module = 1000000033L;
			long somme = 0L;
			
			for (int n = 1; n <= taille; n++) {
				for (int m = 1; m < n; m++) {
					
					somme += 2 * new P434(n, m).getNombreConfig();
					if (somme >= module) {
						somme = somme % module;
					}
				}
				somme += new P434(n, n).getNombreConfig();
				if (somme >= module) {
					somme = somme % module;
				}
			}
			
			return somme;
		}
	}
}