using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Module1.Task1.Diagnostics;
using MentoringD1D2.Module1.Task1.Helpers;

namespace MentoringD1D2.Module1.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int bound;
            Console.WriteLine("Bound: ");
            if (int.TryParse(Console.ReadLine(), out bound))
            {
                List<int> primeNumbers = PrimeNumbersHelper.GeneratePrimeNumbers(bound).ToList();
                double result = PrimeNumbersHelper.AggregatePrimesDividedByOrderNumber(bound);
                Console.WriteLine("-----------Prime Numbers----------");
                primeNumbers.ForEach(Console.WriteLine);

                Console.WriteLine("-------------Result---------------");
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
