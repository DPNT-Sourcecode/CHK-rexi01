using System;
using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public static class CheckoutSolutionTest
    {
        [TestCase("A,B,C,D", ExpectedResult = 115)]
        [TestCase("A,A,B", ExpectedResult = 130)]
        [TestCase("A,A,A,B,B,C,D", ExpectedResult = 210)]
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
