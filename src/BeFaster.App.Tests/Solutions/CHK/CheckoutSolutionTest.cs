using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public static class CheckoutSolutionTest
    {
        [TestCase("A,B,C,D", ExpectedResult = 115)]
        public static int Checkout(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
