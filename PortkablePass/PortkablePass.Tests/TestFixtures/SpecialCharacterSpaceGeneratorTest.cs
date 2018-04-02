using NUnit.Framework;
using PortkablePass.Cryptography.CharacterSpaceGenerators;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class SpecialCharacterSpaceGeneratorTest
    {
        private ISingularCharacterSpaceGenerator generator;

        [SetUp]
        public void SetUp()
        {
            generator = new SpecialCharacterSpaceGenerator();
        }

        [Test]
        public void TestSpaceIdentifierProperty()
        {
            Assert.AreEqual(generator.SpaceIdentifier, CharacterSpace.Special);
        } 

        [Test]
        public void TestGenerateSingularCharacterSpace()
        {
            Assert.AreEqual(generator.GenerateSingularCharacterSpace(), "`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./");
        } 
    }
}