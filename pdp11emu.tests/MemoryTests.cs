using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace pdp11emu.tests
{
    public class MemoryTests
    {
        [Fact]
        public void ByteReadWrite_ShouldPreserveValue()
        {
            var memory = new Memory(1024); // Assuming 1024 bytes for simplicity
            ushort address = 0x00FA; // Example address
            byte expectedValue = 0xAB;

            memory.WriteByte(address, expectedValue);
            byte actualValue = memory.ReadByte(address);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void WordReadWrite_ShouldPreserveValue()
        {
            var memory = new Memory(1024);
            ushort address = 0x0102; // Example address
            ushort expectedValue = 0xABCD;

            memory.WriteWord(address, expectedValue);
            ushort actualValue = memory.ReadWord(address);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void MisalignedWordReadWrite_ShouldPreserveValue()
        {
            var memory = new Memory(1024);
            ushort address = 0x0103; // Misaligned address
            ushort expectedValue = 0xABCD;

            memory.WriteWord(address, expectedValue);
            ushort actualValue = memory.ReadWord(address);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void ReadWriteBeyondBounds_ShouldThrowException()
        {
            var memory = new Memory(1024);
            ushort address = 0xFFFF; // Address beyond the bounds of memory

            // Expect an exception when writing or reading beyond memory bounds
            Assert.Throws<IndexOutOfRangeException>(() => memory.WriteByte(address, 0xFF));
            Assert.Throws<IndexOutOfRangeException>(() => memory.ReadByte(address));
        }
    }
}
