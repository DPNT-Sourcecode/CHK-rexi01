using BeFaster.App.Solutions.HLO;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [TestCase("Bob", ExpectedResult = "Hello Bob")]
        public static string DisplayHelloFriend(string friendName)
        {
            return HelloSolution.Hello(friendName);
        }
    }
}
