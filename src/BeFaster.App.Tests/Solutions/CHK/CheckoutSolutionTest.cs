using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public static class CheckoutSolutionTest
    {
        [TestCase("", ExpectedResult = 1)]
        public static int Checkout(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
