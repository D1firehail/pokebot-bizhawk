using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokebot_Sharp
{
    public class MemoryAddress
    {
        public long StartAddress { get; init; }
        public int Length { get; init; }
        public string? Domain { get; init; }
        public MemoryAddress(long startAddress, int length, string? domain = null) 
        { 
            StartAddress = startAddress & 0xFFFFFF;
            Length = length;
            Domain = domain;
        }
    }
}
