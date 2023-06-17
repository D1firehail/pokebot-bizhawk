using BizHawk.Client.Common;

namespace Pokebot_Sharp.MemoryAddress
{
    public class ClassMemoryAddress<T> : MemoryAddressBase where T : IMemoryReadable
    {
        public ClassMemoryAddress(long startAddress)
        {
            StartAddress = startAddress;
        }

        public void ReadInto(IMemoryApi memoryApi, T target)
        {
            target.ReadFromMemory(memoryApi, StartAddress);
        }
    }
}
