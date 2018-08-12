using System;
using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public static class CheckoutSolutionTest
    {
        [TestCase("BBBEE", ExpectedResult = 85)]
        [TestCase("ABBEE", ExpectedResult = 160)]
        [TestCase("ABCDE", ExpectedResult = 155)]
        [TestCase("ABCD", ExpectedResult = 115)]
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("AAAAA", ExpectedResult = 200)]
        [TestCase("AAAAAA", ExpectedResult = 250)]
        [TestCase("AAAAAAAA", ExpectedResult = 330)]
        [TestCase("AAAAAAAAA", ExpectedResult = 380)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("", ExpectedResult = 0)]
        public static int Checkout(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
