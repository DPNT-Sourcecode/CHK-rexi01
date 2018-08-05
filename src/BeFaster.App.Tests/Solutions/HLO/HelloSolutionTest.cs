using BeFaster.App.Solutions.HLO;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [TestCase("Craftman", ExpectedResult = "Hello, world!")]
        public static void DisplayHelloFriend(string friendName)
        {
            return HelloSolution.Hello(friendName);
        }
    }
}
