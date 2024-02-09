using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdp11emu
{
    public class Memory : IMemory
    {
        private byte[] memory;

        public Memory(int size)
        {
            memory = new byte[size];
        }

        public byte ReadByte(ushort address)
        {
            // Assuming address is already in the correct base (octal for PDP-11)
            return memory[address];
        }

        public void WriteByte(ushort address, byte data)
        {
            memory[address] = data;
        }

        public ushort ReadWord(ushort address)
        {
            // Combine two bytes into a word, considering PDP-11's little-endian format
            return (ushort)(memory[address] | (memory[address + 1] << 8));
        }

        public void WriteWord(ushort address, ushort data)
        {
            // Split the word into two bytes and store, considering PDP-11's little-endian format
            memory[address] = (byte)(data & 0xFF);
            memory[address + 1] = (byte)((data >> 8) & 0xFF);
        }
    }
}
