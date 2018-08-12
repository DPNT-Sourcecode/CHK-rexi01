using System;
using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public static class CheckoutSolutionTest
    {
        [TestCase("HHHHHHHHHHHH", ExpectedResult = 100)]
        [TestCase("HHHHHHHHHHH", ExpectedResult = 90)]
        [TestCase("HHHHHHHHHH", ExpectedResult = 80)]
        [TestCase("FFFFFFFFF", ExpectedResult = 60)]
        [TestCase("FFFFFFFF", ExpectedResult = 60)]
        [TestCase("FFFFFFF", ExpectedResult = 50)]
        [TestCase("FFFFFF", ExpectedResult = 40)]
        [TestCase("FFFFF", ExpectedResult = 40)]
        [TestCase("FFFF", ExpectedResult = 30)]
        [TestCase("FFF", ExpectedResult = 20)]
        [TestCase("FF", ExpectedResult = 20)]
        [TestCase("F", ExpectedResult = 10)]
        [TestCase("ABCDECBAABCABBAAAEEAA", ExpectedResult = 665)]
        [TestCase("CCADDEEBBA", ExpectedResult = 280)]
        [TestCase("ABCDEABCDE", ExpectedResult = 280)]
        [TestCase("BBB", ExpectedResult = 75)]
        [TestCase("BEBEEE", ExpectedResult = 160)]
        [TestCase("EEEEBB", ExpectedResult = 160)]
        [TestCase("BBBEE", ExpectedResult = 125)]
        [TestCase("ABBEE", ExpectedResult = 160)]
        [TestCase("EEEB", ExpectedResult = 120)]
        [TestCase("EEB", ExpectedResult = 80)]
        [TestCase("EE", ExpectedResult = 80)]
        [TestCase("ABCDE", ExpectedResult = 155)]
        [TestCase("ABCD", ExpectedResult = 115)]
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("AAAAA", ExpectedResult = 200)]
        [TestCase("AAAAAA", ExpectedResult = 250)]
        [TestCase("AAAAAAAA", ExpectedResult = 330)]
        [TestCase("AAAAAAAAA", ExpectedResult = 380)]
        [TestCase("AAAAAAAAAA", ExpectedResult = 400)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("ABCa", ExpectedResult = -1)]
        [TestCase("-", ExpectedResult = -1)]
        [TestCase("a", ExpectedResult = -1)]
        [TestCase("A", ExpectedResult = 50)]
        [TestCase("", ExpectedResult = 0)]
        public static int Checkout(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
