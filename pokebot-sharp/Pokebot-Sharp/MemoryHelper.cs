using BizHawk.Client.Common;
using Pokebot_Sharp.MemoryAddress;

namespace Pokebot_Sharp
{
    public static class MemoryHelper
    {
        private static SimpleMemoryAddress m_SimpleAddress = new SimpleMemoryAddress(0, 0);

        public static uint Read(long address, int length, IMemoryApi api)
        {
            m_SimpleAddress.SetTarget(address, length);
            return m_SimpleAddress.Read(api);
        }

    }
}
