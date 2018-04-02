using Moq;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Tests.Mocks
{
    public class Uft8ConverterMockCreator
    {
        public static Mock<IUtf8Converter> CreateUtf8Mock()
        {
            var mockUtf8Converter = new Mock<IUtf8Converter>();

            mockUtf8Converter.Setup(p => p.ConvertToBytes("aaa")).Returns(new byte[] {0x61, 0x61, 0x61});
            mockUtf8Converter.Setup(p => p.ConvertToBytes("ść")).Returns(new byte[] {0xc5, 0x9b, 0xc4, 0x87});
            mockUtf8Converter.Setup(p => p.ConvertToBytes("")).Returns(new byte[] { });

            return mockUtf8Converter;
        }
    }
}