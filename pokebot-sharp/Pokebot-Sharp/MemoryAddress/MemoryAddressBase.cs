using System;

namespace Pokebot_Sharp.MemoryAddress
{
    public abstract class MemoryAddressBase
    {
        public const string BIOS = "BIOS";
        public const string EWRAM = "EWRAM";
        public const string IWRAM = "IWRAM";
        public const string ROM = "ROM";
        public const long Bitmask = 0xFFFFFF;

        private long m_StartAddress;

        protected long m_ConcatAddress { get; private set; }

        public string? Domain { get; protected set; }


        public long StartAddress
        {
            get => m_StartAddress;
            protected set
            {
                SetDomain(value);
                m_ConcatAddress = value & Bitmask;
                m_StartAddress = value;
            }
        }

        protected void SetDomain(long address)
        {
            Domain = (address >> 24) switch
            {
                0 => "BIOS",
                2 => "EWRAM",
                3 => "IWRAM",
                8 => "ROM",
                _ => throw new NotImplementedException("unknown address band"),
            };
        }
    }


}
