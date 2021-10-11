using System;

namespace SigmaHT_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rows of matrix:");
            int rows;
            if(!int.TryParse(Console.ReadLine(), out rows))
            {
                Console.WriteLine("Incorrect data");
                return;
            }

            Console.WriteLine("Enter rows of matrix:");
            int columns;
            if(!int.TryParse(Console.ReadLine(), out columns))
            {
                Console.WriteLine("Incorrect data");
                return;
            }


            Matrix matrix;

            try
            {
                matrix = new Matrix(rows, columns);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            matrix.FillMatrixForDefault();

            Console.WriteLine($"Matrix:\n{matrix}");

            Console.WriteLine("Elements of matrix in reversed order:\n");

            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
        }
    }
}
