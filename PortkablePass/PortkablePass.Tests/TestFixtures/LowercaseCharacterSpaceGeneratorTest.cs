using NUnit.Framework;
using PortkablePass.Cryptography.CharacterSpaceGenerators;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class LowercaseCharacterSpaceGeneratorTest
    {
        private ISingularCharacterSpaceGenerator generator;

        [SetUp]
        public void SetUp()
        {
            generator = new LowercaseCharacterSpaceGenerator();
        }

        [Test]
        public void TestSpaceIdentifierProperty()
        {
            Assert.AreEqual(generator.SpaceIdentifier, CharacterSpace.Lowercase);
        } 

        [Test]
        public void TestGenerateSingularCharacterSpace()
        {
            Assert.AreEqual(generator.GenerateSingularCharacterSpace(), "abcdefghijklmnopqrstuvwxyz");
        } 
    }
}