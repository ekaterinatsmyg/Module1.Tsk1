using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Module1.Task1.Diagnostics;

namespace MentoringD1D2.Module1.Task1.Helpers
{
    /// <summary>
    /// The prime numbers helper.
    /// </summary>
    public static class PrimeNumbersHelper
    {
        #region Constants

        /// <summary>
        /// The minimum prime number
        /// </summary>
        private const int MinPrimeNumber = 2;

        /// <summary>
        /// The upper bound of generation of prime numbers
        /// </summary>
        private const int MaxPrimeNumber = 1000000000;
        #endregion

        #region Methods

        /// <summary>
        /// Genrate a list of prime numbers beetween 2 and bound value
        /// </summary>
        /// <param name="bound">An upper bound of a sample of prime numbers</param>
        /// <returns>A list of prime numbers beetween 2 and bound value</returns>
        public static IEnumerable<int> GeneratePrimeNumbers(int bound)
        {
            if (bound < MinPrimeNumber || bound > MaxPrimeNumber)

            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The upper limit is less than {MinPrimeNumber} or grater than {MaxPrimeNumber}. MethodInfo: {MethodBase.GetCurrentMethod()}");
                yield break;
            }

            yield return 2;

            BitArray composite = new BitArray((bound - 1) / 2);
            int limit = ((int)(Math.Sqrt(bound)) - 1) / 2;
            for (int i = 0; i < limit; i++)
            {
                if (composite[i]) continue;

                int prime = 2 * i + 3;
                yield return prime;

                for (int j = (prime * prime - 2) >> 1; j < composite.Count; j += prime)
                {
                    composite[j] = true;
                }
            }

            for (int i = limit; i < composite.Count; i++)
            {
                if (!composite[i]) yield return 2 * i + 3;
            }

        }

        /// <summary>
        /// Calculate sum of primes divided by its own order number beetween 2 and bound value.
        /// </summary>
        /// <param name="bound">An upper bound of a sample of prime numbers</param>
        /// <returns>A sum of prime numbers divided by its own order number beetween 2 and bound value.</returns>
        public static double AggregatePrimesDividedByOrderNumber(int bound)
        {
            double sum = 0;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var primeNumbers = GeneratePrimeNumbers(bound).ToList();

            stopWatch.Stop();
            ApplicationLogger.LogMessage(LogMessageType.Debug, $"Generation of prime numbers took {stopWatch.Elapsed.Hours}:{stopWatch.Elapsed.Minutes}:{stopWatch.Elapsed.Seconds}.{stopWatch.Elapsed.TotalMilliseconds}");
            for (int i = 0; i < primeNumbers.Count(); i++)
            {
                sum += Convert.ToDouble(primeNumbers[i] / (i + 1));
            }
            return Math.Floor(sum);


        }


        #endregion
    }
}
