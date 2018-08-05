using BeFaster.App.Solutions.HLO;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [TestCase("world", ExpectedResult = "Hello, world")]
        public static string DisplayHelloFriend(string friendName)
        {
            return HelloSolution.Hello(friendName);
        }
    }
}
