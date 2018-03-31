using NUnit.Framework;
using PortkablePass.Encoding;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class HmacToArbitraryEncodingConverterTest
    {
        private IHmacToArbitraryEncodingConverter hmacToArbitraryEncodingConverter;

        [SetUp]
        public void SetUp()
        {
            hmacToArbitraryEncodingConverter = new HmacToArbitraryEncodingConverter();
        }

        [TestCase(new byte[]
        {
            97, 97, 97, 97, 97, 97, 97, 97,
            97, 97, 97, 97, 97, 97, 97, 97,
            97, 97, 97, 97, 97, 97, 97, 97,
            97, 97, 97, 97, 97, 97, 97, 97,
        }, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 
            ExpectedResult = "CPNS4HSGUZ97ERJ0Y2GO0VNTQRNC43FR7AOILOUWALU6SK7DN3")]
        [TestCase(new byte[]
            {
                97, 98, 99, 100, 101, 102, 103, 104,
                105, 106, 107, 108, 109, 110, 111, 112,
                113, 114, 115, 116, 117, 118, 119, 120,
                121, 122, 97, 98, 99, 100, 101, 102
            }, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",
            ExpectedResult = "XFuygFkabbrRvADCQtTooFmiZTn1mqLrIrtuf5NOPVU")]
        [TestCase(new byte[]
            {
                97, 98, 99, 100, 101, 102, 103, 104,
                105, 106, 107, 108, 109, 110, 111, 112,
                113, 114, 115, 116, 117, 118, 119, 120,
                121, 122, 97, 98, 99, 100, 101, 102
            }, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./",
            ExpectedResult = "AuXHd\"szXp)PA\\`bA:M!6gVBA6QF77v[r+QGP$:a")]
        [TestCase(new byte[]
            {
                97, 98, 99, 100, 101, 102, 103, 104,
                105, 106, 107, 108, 109, 110, 111, 112,
                113, 114, 115, 116, 117, 118, 119, 120,
                121, 122, 97, 98, 99, 100, 101, 102
            }, "0123456789",
            ExpectedResult = "044048183304486788312148433451363384677562265908331949128489393251112035050854")]
        public string TestConvertToArbitraryEncodedString(byte[] input, string encoding)
        {
            return hmacToArbitraryEncodingConverter.ConvertToArbitraryEncodedString(input, encoding);
        }
    }
}