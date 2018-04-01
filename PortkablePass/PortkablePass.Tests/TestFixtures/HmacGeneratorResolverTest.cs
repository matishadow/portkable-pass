using Moq;
using NUnit.Framework;
using PortkablePass.Cryptography;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class HmacGeneratorResolverTest
    {
        private IHmacGeneratorResolver hmacGeneratorResolver;

        [SetUp]
        public void SetUp()
        {
            var hmacSha1GeneratorMock = new Mock<IHmacSha1Generator>();
            hmacSha1GeneratorMock.Setup(h => h.HmacGenerator).Returns(HmacGenerator.Sha1);

            var hmacSha256GeneratorMock = new Mock<IHmacSha256Generator>();
            hmacSha256GeneratorMock.Setup(h => h.HmacGenerator).Returns(HmacGenerator.Sha256);

            var hmacSha512GeneratorMock = new Mock<IHmacSha512Generator>();
            hmacSha512GeneratorMock.Setup(h => h.HmacGenerator).Returns(HmacGenerator.Sha512);

            hmacGeneratorResolver = new HmacGeneratorResolver(new IHmacGenerator[]
                {hmacSha1GeneratorMock.Object, hmacSha256GeneratorMock.Object, hmacSha512GeneratorMock.Object});
        }

        [TestCase(HmacGenerator.Sha1)]
        [TestCase(HmacGenerator.Sha256)]
        [TestCase(HmacGenerator.Sha512)]
        public void TestResolveHmacSha1Generator(HmacGenerator hmacGenerator)
        {
            IHmacGenerator sha1HmacGenerator = hmacGeneratorResolver.ResolverHmacGenerator(hmacGenerator);

            Assert.AreEqual(sha1HmacGenerator.HmacGenerator, hmacGenerator);
        }
    }
}