using BizHawk.Client.Common;
using Pokebot_Sharp.MemoryAddress;

namespace Pokebot_Sharp.AddressCollection
{
    public class Emer_U_AddressCollection : IAddressCollection
    {
        private SimpleMemoryAddress m_Trainer;
        private PointedMemoryAddess m_Tid;
        private PointedMemoryAddess m_Sid;
        public Emer_U_AddressCollection()
        {
            TrainerPointer = 0x3005D90;
            Coords = 0x2037360;
            MapBank = 0x203BC80;
            EnemyStats = 0x2024744;
            uint pstats = 0x20244EC;
            uint pcount = 0x20244E9;
            uint sniffLocation = 0x3007660;
            StartScreenSniffer = new SimpleMemoryAddress(sniffLocation, 4);
            TrainerState = new SimpleMemoryAddress(TrainerPointer + 199, 1);
            MapId = new SimpleMemoryAddress(TrainerPointer + 200, 1);
            TrainerMapBank = new SimpleMemoryAddress(TrainerPointer + 201, 1);
            PosX = new SimpleMemoryAddress(Coords + 0, 1);
            PosY = new SimpleMemoryAddress(Coords + 2, 1);
            Facing = new SimpleMemoryAddress(Coords + 8, 1);
            Enemy = new ClassMemoryAddress<Mon>(EnemyStats);
            PartyCount = new SimpleMemoryAddress(pcount, 1);
            Party = new ClassMemoryAddress<MonParty>(pstats);
            m_Trainer = new SimpleMemoryAddress(TrainerPointer, 4);
            m_Tid = new PointedMemoryAddess(m_Trainer, 2, 10);
            m_Sid = new PointedMemoryAddess(m_Trainer, 2, 12);
        }

        public IMemoryApi? MemoryApi { get; set; }
        public uint TrainerPointer { get; }

        public uint Coords { get; }
        public uint MapBank { get; }

        public uint EnemyStats { get; }

        public SimpleMemoryAddress StartScreenSniffer { get; }

        public SimpleMemoryAddress TrainerState { get; }

        public SimpleMemoryAddress MapId { get; }

        public SimpleMemoryAddress TrainerMapBank { get; }

        public SimpleMemoryAddress PosX { get; }

        public SimpleMemoryAddress PosY { get; }

        public SimpleMemoryAddress Tid => m_Tid;

        public SimpleMemoryAddress Sid => m_Sid;

        public SimpleMemoryAddress Facing { get; }

        public ClassMemoryAddress<Mon> Enemy { get; }
        public SimpleMemoryAddress PartyCount { get; }
        public ClassMemoryAddress<MonParty> Party { get; }

        public void ResetPointedAddresses()
        {
            m_Tid.ResetPointer();
            m_Sid.ResetPointer();
        }
    }
}
