using Xunit;

namespace pdp11emu.tests
{
    public class CpuTets
    {
        [Fact(DisplayName = "All registers are set to 0 after the reset")]
        public void RegisterInitializationTest()
        {
            var cpu = new Cpu(new Memory(2));
            cpu.Reset();
            Assert.Equal(0, cpu.R0);
            Assert.Equal(0, cpu.R1);
            Assert.Equal(0, cpu.R2);
            Assert.Equal(0, cpu.R3);
            Assert.Equal(0, cpu.R4);
            Assert.Equal(0, cpu.R5);
            Assert.Equal(0, cpu.R6);
            Assert.Equal(0, cpu.R7);
        }

        private Memory CreateMemoryWithNopInstructions(int instructionCount)
        {
            var memory = new Memory(1024); // Adjust size as needed
            for (int i = 0; i < instructionCount * 2; i += 2)
            {
                memory.WriteWord((ushort)i, 0x0000); // Writing NOP instructions
            }
            return memory;
        }

        [Fact]
        public void Cpu_ShouldIncrementPC_OnNopInstruction()
        {
            var memory = CreateMemoryWithNopInstructions(1);
            var cpu = new Cpu(memory);
            cpu.Reset();
            ushort initialPC = cpu.PC;

            cpu.Clock(); // Simulate one clock impulse to execute NOP

            Assert.Equal(initialPC + 2, cpu.PC); // PC should increment by 2 for a single NOP instruction
        }

        [Fact]
        public void Cpu_ShouldCorrectlyHandle_MultipleNopInstructions()
        {
            int nopCount = 5;
            var memory = CreateMemoryWithNopInstructions(nopCount);
            var cpu = new Cpu(memory);
            cpu.Reset();
            ushort initialPC = cpu.PC;

            for (int i = 0; i < nopCount; i++)
            {
                cpu.Clock(); // Simulate clock impulses to execute NOPs
            }

            Assert.Equal(initialPC + (2 * nopCount), cpu.PC); // PC should increment by 2 for each NOP
        }

/*        [Fact]
        public void Cpu_ShouldNotAlterState_BesidesPC_OnNopInstruction()
        {
            var memory = CreateMemoryWithNopInstructions(1);
            var cpu = new Cpu(memory);
            cpu.Reset();
            // Capture initial state (besides PC)
            // Example: ushort initialR0 = cpu.R0;

            cpu.Clock(); // Execute NOP

            // Verify state is unchanged (besides PC)
            // Assert.Equal(initialR0, cpu.R0);
            // Add similar assertions for other registers if needed
        }*/

    }
}