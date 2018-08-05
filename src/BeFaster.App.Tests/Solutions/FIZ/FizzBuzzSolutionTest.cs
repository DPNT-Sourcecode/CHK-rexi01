using BeFaster.App.Solutions.FIZ;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.FIZ
{
    [TestFixture]
    public static class FizzBuzzSolutionTest
    {
        [TestCase(1, ExpectedResult = "1")]
        public static string PrintFizzBuzz(int number)
        {
            return FizzBuzzSolution.FizzBuzz(number);
        }
    }
}
