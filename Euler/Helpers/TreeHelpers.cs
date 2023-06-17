// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Helpers
{
    using Euler.Utils;

    public static class TreeHelpers
    {
        public static Tree BuildTriangle(int[][] triangle)
        {
            int size = triangle.Length;
            Tree[][] bucheron = new Tree[size][];
            for (int i = 0; i < size; i++)
            {
                bucheron[i] = new Tree[size];
                for (int j = 0; j <= i; j++)
                {
                    Tree tree = new Tree(triangle[i][j]);
                    bucheron[i][j] = tree;
                    if (i > 0)
                    {
                        if (j < i)
                        {
                            bucheron[i - 1][j].AddSon(tree);
                        }
                        if (j > 0)
                        {
                            bucheron[i - 1][j - 1].AddSon(tree);
                        }
                    }
                }
            }
            return bucheron[0][0];
        }

        public static Tree BuildMatrix(int[][] matrix)
        {
            int size = matrix.Length;
            Tree[][] bucheron = new Tree[size][];
            for (int i = 0; i < size; i++)
            {
                bucheron[i] = new Tree[size];
                for (int j = 0; j < size; j++)
                {
                    Tree tree = new Tree(matrix[i][j]);
                    bucheron[i][j] = tree;
                    if (i > 0)
                    {
                        bucheron[i - 1][j].AddSon(tree);
                    }
                    if (j > 0)
                    {
                        bucheron[i][j - 1].AddSon(tree);
                    }

                }
            }
            return bucheron[0][0];
        }

    }
}
