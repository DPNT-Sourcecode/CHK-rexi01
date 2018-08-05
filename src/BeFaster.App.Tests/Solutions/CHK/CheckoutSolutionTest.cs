using System;
using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public static class CheckoutSolutionTest
    {
        [TestCase("ABCD", ExpectedResult = 115)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("", ExpectedResult = 0)]
        public static int Checkout(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }

        //[Test]
        //public static void CheckoutInvalidItem(string skus)
        //{
        //    Assert.Throws<ArgumentException>(() => CheckoutSolution.Checkout(skus));
        //}
    }
}
