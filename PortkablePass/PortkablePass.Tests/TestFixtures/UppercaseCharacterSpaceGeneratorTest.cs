using NUnit.Framework;
using PortkablePass.Cryptography.CharacterSpaceGenerators;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class UppercaseCharacterSpaceGeneratorTest
    {
        private ISingularCharacterSpaceGenerator generator;

        [SetUp]
        public void SetUp()
        {
            generator = new UppercaseCharacterSpaceGenerator();
        }

        [Test]
        public void TestSpaceIdentifierProperty()
        {
            Assert.AreEqual(generator.SpaceIdentifier, CharacterSpace.Uppercase);
        } 

        [Test]
        public void TestGenerateSingularCharacterSpace()
        {
            Assert.AreEqual(generator.GenerateSingularCharacterSpace(), "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        } 
    }
}