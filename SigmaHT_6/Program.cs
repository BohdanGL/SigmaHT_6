using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHT_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first polinomial:");

            Polynomial polynomial1 = new Polynomial();
            try
            {
                polynomial1.Parse(Console.ReadLine());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Enter second polinomial:");

            Polynomial polynomial2 = new Polynomial();

            try
            {
                polynomial2.Parse(Console.ReadLine());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\nSum of polinomials: " + (polynomial1 + polynomial2));
            Console.WriteLine("\nSubtractiong of first and second polinomals: " + (polynomial1 - polynomial2));
            Console.WriteLine("\nMultyplying of polinominals: " + (polynomial1 * polynomial2));
        }
    }
}
