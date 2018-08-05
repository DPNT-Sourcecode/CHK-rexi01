using BeFaster.App.Solutions.HLO;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [TestCase("Craftsman", ExpectedResult = "Hello, World!")]
        public static string DisplayHelloWorld(string friendName)
        {
            return HelloSolution.Hello(friendName);
        }
    }
}
