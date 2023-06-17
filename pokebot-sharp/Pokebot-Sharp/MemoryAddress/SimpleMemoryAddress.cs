using BizHawk.Client.Common;
using System;

namespace Pokebot_Sharp.MemoryAddress
{
    public class SimpleMemoryAddress : MemoryAddressBase
    {
        public int Length { get; protected set; }

        protected SimpleMemoryAddress()
        {
        }

        public SimpleMemoryAddress(long startAddress, int length)
        {
            StartAddress = startAddress;
            Length = length;
        }

        public void SetTarget(long startAddress, int length)
        {
            StartAddress = startAddress;
            Length = length;
        }

        public virtual uint Read(IMemoryApi memoryApi)
        {
            return Length switch
            {
                1 => memoryApi.ReadU8(m_ConcatAddress, Domain),
                2 => memoryApi.ReadU16(m_ConcatAddress, Domain),
                3 => memoryApi.ReadU24(m_ConcatAddress, Domain),
                4 => memoryApi.ReadU32(m_ConcatAddress, Domain),
                _ => throw new NotImplementedException("Unsupported address length")
            };
        }
    }
}
