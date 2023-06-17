using BizHawk.Client.Common;
using Pokebot_Sharp.MemoryAddress;
using System.Collections.Generic;

namespace Pokebot_Sharp
{
    public class MonParty : IMemoryReadable
    {
        private SimpleMemoryAddress m_PartyCount;
        public MonParty(SimpleMemoryAddress partyCount)
        {
            m_PartyCount = partyCount;
        }
        public List<Mon> Mons { get; } = new List<Mon>();
        public void ReadFromMemory(IMemoryApi memoryApi, long address)
        {
            Mons.Clear();
            uint partyCount = m_PartyCount.Read(memoryApi);
            for (uint i = 0; i < partyCount; i++)
            {
                Mon newMon = new Mon();
                newMon.ReadFromMemory(memoryApi, address + 100 * i);
            }
        }
    }
}
