using BizHawk.Client.Common;

namespace Pokebot_Sharp
{
    public interface IMemoryReadable
    {
        public void ReadFromMemory(IMemoryApi memoryApi, long address, string? domain);
    }
}
