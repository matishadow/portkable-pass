using System;
using System.Linq;
using NUnit.Framework;
using PortkablePass.Encoding;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class Utf8ConverterTest
    {
        private IUtf8Converter converter;

        [SetUp]
        public void SetUp()
        {
            converter = new Utf8Converter();
        }

        [TestCase("abc", ExpectedResult = new byte[] {0x61, 0x62, 0x63})]
        public byte[] TestConvertToBytes(string input)
        {
            return converter.ConvertToBytes(input);
        }

        [Test]
        public void TestArgumentNull()
        {
            Assert.Throws<ArgumentException>(() => { converter.ConvertToBytes(null); });
        }

        [Test]
        public void TestArgumentEmpty()
        {
            Assert.Throws<ArgumentException>(() => { converter.ConvertToBytes(string.Empty); });
        }
    }
}