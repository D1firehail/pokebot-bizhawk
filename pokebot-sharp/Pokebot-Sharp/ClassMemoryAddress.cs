using BizHawk.Client.Common;

namespace Pokebot_Sharp
{
    public class ClassMemoryAddress<T> where T : IMemoryReadable
    {
        public long StartAddress { get; init; }
        public string? Domain { get; init; }
        public ClassMemoryAddress(long startAddress, string? domain = null)
        {
            StartAddress = startAddress & SimpleMemoryAddress.Bitmask;
            Domain = domain;
        }

        public void ReadInto(IMemoryApi memoryApi, T target)
        {
            target.ReadFromMemory(memoryApi, StartAddress, Domain);
        }
    }
}
