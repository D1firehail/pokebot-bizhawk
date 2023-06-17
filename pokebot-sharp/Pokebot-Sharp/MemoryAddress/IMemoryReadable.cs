using BizHawk.Client.Common;

namespace Pokebot_Sharp.MemoryAddress
{
    public interface IMemoryReadable
    {
        public void ReadFromMemory(IMemoryApi memoryApi, long address);
    }
}
