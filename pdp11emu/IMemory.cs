namespace pdp11emu
{
    public interface IMemory
    {
        byte ReadByte(ushort address);
        void WriteByte(ushort address, byte data);
        ushort ReadWord(ushort address);
        void WriteWord(ushort address, ushort data);
    }
}
