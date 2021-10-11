using System;
using System.Collections;
using System.Collections.Generic;

namespace SigmaHT_6_3
{
    class Matrix : IEnumerable<int>
    {
        private int[,] matrix;

        public int Columns { get; private set; }

        public int Rows { get; private set; }

        public Matrix(int cols,int rows)
        {
            if (cols <= 0 || rows <= 0)
                throw new ArgumentException("Bad dimensions of matrix");

            Columns = cols;
            Rows = rows;

            matrix = new int[Rows, Columns];

        }

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public override string ToString()
        {
            string output = String.Empty;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    output += String.Format("{0,-5}",matrix[i, j]);
                }
                output += "\n";
            }

            return output;
        }

        public void FillMatrixForDefault()
        {
            for (int i = 0, N = 1; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++, N++)
                {
                    matrix[i, j] = N;
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    yield return matrix[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
