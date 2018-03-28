using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PortkablePass.Cryptography.CharacterSpaceGenerators;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Tests.TestFixtures
{
    [TestFixture]
    public class CharacterSpaceGeneratorTest
    {
        private const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DigitsCharacters = "0123456789";
        private const string SpecialCharacters = "`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./";

        private ICharacterSpaceGenerator generator;

        [SetUp]
        public void SetUp()
        {
            generator = new CharacterSpaceGenerator(GenerateISingularCharacterSpaceGenerators());
        }

        [TestCase(CharacterSpace.Lowercase, ExpectedResult = LowercaseCharacters)]
        [TestCase(CharacterSpace.Uppercase, ExpectedResult = UppercaseCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Uppercase, ExpectedResult =
            LowercaseCharacters + UppercaseCharacters)]
        [TestCase(CharacterSpace.Digits, ExpectedResult = DigitsCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Digits, ExpectedResult =
            LowercaseCharacters + DigitsCharacters)]
        [TestCase(CharacterSpace.Uppercase | CharacterSpace.Digits, ExpectedResult =
            UppercaseCharacters + DigitsCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Uppercase | CharacterSpace.Digits, ExpectedResult =
            LowercaseCharacters + UppercaseCharacters + DigitsCharacters)]
        [TestCase(CharacterSpace.Special, ExpectedResult = SpecialCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Special, ExpectedResult =
            LowercaseCharacters + SpecialCharacters)]
        [TestCase(CharacterSpace.Uppercase | CharacterSpace.Special, ExpectedResult =
            UppercaseCharacters + SpecialCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Uppercase | CharacterSpace.Special, ExpectedResult =
            LowercaseCharacters + UppercaseCharacters + SpecialCharacters)]
        [TestCase(CharacterSpace.Digits | CharacterSpace.Special, ExpectedResult =
            DigitsCharacters + SpecialCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Digits | CharacterSpace.Special, ExpectedResult =
            LowercaseCharacters + DigitsCharacters + SpecialCharacters)]
        [TestCase(CharacterSpace.Uppercase | CharacterSpace.Digits | CharacterSpace.Special, ExpectedResult =
            UppercaseCharacters + DigitsCharacters + SpecialCharacters)]
        [TestCase(CharacterSpace.Lowercase | CharacterSpace.Uppercase | CharacterSpace.Digits | CharacterSpace.Special,
            ExpectedResult = LowercaseCharacters + UppercaseCharacters + DigitsCharacters + SpecialCharacters)]
        public string TestGenerateCharacterSpace(CharacterSpace characterSpace)
        {
            return generator.GenerateCharacterSpace(characterSpace);
        }

        private static IEnumerable<ISingularCharacterSpaceGenerator> GenerateISingularCharacterSpaceGenerators()
        {
            var lowercaseCharacterSpaceGeneratorMock = new Mock<ISingularCharacterSpaceGenerator>();
            lowercaseCharacterSpaceGeneratorMock.Setup(g => g.GenerateSingularCharacterSpace())
                .Returns(LowercaseCharacters);
            lowercaseCharacterSpaceGeneratorMock.Setup(g => g.SpaceIdentifier).Returns(CharacterSpace.Lowercase);

            var uppercaseCharacterSpaceGeneratorMock = new Mock<ISingularCharacterSpaceGenerator>();
            uppercaseCharacterSpaceGeneratorMock.Setup(g => g.GenerateSingularCharacterSpace())
                .Returns(UppercaseCharacters);
            uppercaseCharacterSpaceGeneratorMock.Setup(g => g.SpaceIdentifier).Returns(CharacterSpace.Uppercase);

            var digitCharacterSpaceGeneratorMock = new Mock<ISingularCharacterSpaceGenerator>();
            digitCharacterSpaceGeneratorMock.Setup(g => g.GenerateSingularCharacterSpace())
                .Returns(DigitsCharacters);
            digitCharacterSpaceGeneratorMock.Setup(g => g.SpaceIdentifier).Returns(CharacterSpace.Digits);
            
            var specialCharacterSpaceGeneratorMock = new Mock<ISingularCharacterSpaceGenerator>();
            specialCharacterSpaceGeneratorMock.Setup(g => g.GenerateSingularCharacterSpace())
                .Returns(SpecialCharacters);
            specialCharacterSpaceGeneratorMock.Setup(g => g.SpaceIdentifier).Returns(CharacterSpace.Special);

            return new[]
            {
                lowercaseCharacterSpaceGeneratorMock.Object, uppercaseCharacterSpaceGeneratorMock.Object,
                digitCharacterSpaceGeneratorMock.Object, specialCharacterSpaceGeneratorMock.Object
            };
        }
    }
}