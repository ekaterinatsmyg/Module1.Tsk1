using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MentoringD1D2.Module1.Task1.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MentoringD1D2.Module1.Task1.Tests
{
    /// <summary>
    /// The Generator of Simple Numbers Tests.
    /// </summary>
    [TestClass]
    public class PrimeNumbersGeneratorTest
    {
        /// <summary>
        /// The prime numbers up to one hundred
        /// </summary>
        private readonly List<int> _testPrimeNumbers = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            
            
        [TestMethod]
        public void GeneratePrimeNumbersMinimalBoundTest()
        {
            Random random = new Random();
            var actualResult = PrimeNumbersHelper.GeneratePrimeNumbers(random.Next(-1, 1)); 
            Assert.AreEqual(0, actualResult.Count());
        }

        [TestMethod]
        public void GeneratePrimeNumbersMaxiumBoundTest()
        {
            var actualResult = PrimeNumbersHelper.GeneratePrimeNumbers(1100000000);
            Assert.AreEqual(0, actualResult.Count());
        }

        [TestMethod]
        public void GeneratePrimeTest()
        {
            var actualResult = PrimeNumbersHelper.GeneratePrimeNumbers(100).ToList();
            CollectionAssert.AreEqual(_testPrimeNumbers, actualResult);
        }
    }
}
