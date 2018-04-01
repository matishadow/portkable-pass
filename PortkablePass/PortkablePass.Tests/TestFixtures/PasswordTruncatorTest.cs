using System;
using System.Linq;
using NUnit.Framework;
using PortkablePass.Encoding;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class PasswordTruncatorTest
    {
        private const string ExampleString = "aaaaaaaaaaaaaaaa";
        private const int OutOfRangeLength = 20;
        private const int NegativeLength = -5;
        private const int ExampleLength1 = 5;
        private const int ExampleLength2 = 8;

        private IPasswordTruncator passwordTruncator;

        [SetUp]
        public void SetUp()
        {
            passwordTruncator = new PasswordTruncator();
        }

        [TestCase(null, ExampleLength1, ExpectedResult = null)]
        [TestCase(null, NegativeLength, ExpectedResult = null)]
        [TestCase(ExampleString, ExampleLength1, ExpectedResult = "aaaaa")]
        [TestCase(ExampleString, ExampleLength2, ExpectedResult = "aaaaaaaa")]
        public string TestTruncate(string password, int desiredLength)
        {
            return passwordTruncator.Truncate(password, desiredLength);
        }

        [TestCase(ExampleString, OutOfRangeLength)]
        [TestCase(ExampleString, NegativeLength)]
        public void TestArgumentOutOfRange(string password, int desiredLength)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => passwordTruncator.Truncate(password, desiredLength));
        }
    }
}