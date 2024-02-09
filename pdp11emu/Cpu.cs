using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdp11emu
{
    public class Cpu
    {
        private IMemory memory;

        public Cpu(IMemory memory)
        {
            this.memory = memory;
        }

        public ushort R0 { get; set; }
        public ushort R1 { get; set; }
        public ushort R2 { get; set; }
        public ushort R3 { get; set; }
        public ushort R4 { get; set; }
        public ushort R5 { get; set; }
        public ushort R6 { get; set; }
        public ushort R7 { get; set; }
        public ushort PC { get { return R7; } set { R7 = value; } } // Program Counter
        public ushort SP { get { return R6; } set { R6 = value; } } // Program Counter // Stack Pointer
        public ushort PSW { get; set; } // Processor Status Word


        public void Reset()
        {
            R0 = R1  = R2 = R3 = R4 = R5 = R6 = R7 = PSW = 0;
        }

        public void Clock()
        {
            ushort instruction = memory.ReadWord(PC);
            ExecuteInstruction(instruction);
            PC += 2; // Increment PC to the next instruction (assuming 16-bit instructions)
        }

        private void ExecuteInstruction(ushort instruction)
        {
            // For now, assume all zeroes is NOP
            if (instruction == 0x0000)
            {
                // NOP: Do nothing
                return;
            }
            // Future: Add more instruction handling
        }
    }
}
