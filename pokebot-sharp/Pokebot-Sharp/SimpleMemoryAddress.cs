using BizHawk.Client.Common;
using System;

namespace Pokebot_Sharp
{
    public class SimpleMemoryAddress
    {
        public static long Bitmask = 0xFFFFFF;
        public long StartAddress { get; init; }
        public int Length { get; init; }
        public string? Domain { get; init; }
        public SimpleMemoryAddress(long startAddress, int length, string? domain = null)
        {
            StartAddress = startAddress & Bitmask;
            Length = length;
            Domain = domain;
        }

        public uint Read(IMemoryApi memoryApi)
        {
            return Length switch
            {
                1 => memoryApi.ReadU8(StartAddress, Domain),
                2 => memoryApi.ReadU16(StartAddress, Domain),
                3 => memoryApi.ReadU24(StartAddress, Domain),
                4 => memoryApi.ReadU32(StartAddress, Domain),
                _ => throw new NotImplementedException("Unsupported address length")
            };
        }
    }
}
