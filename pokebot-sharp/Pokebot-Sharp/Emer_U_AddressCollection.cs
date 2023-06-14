using BizHawk.Client.Common;
using System;

namespace Pokebot_Sharp
{
    public class Emer_U_AddressCollection : IAddressCollection
    {
        private static string BIOS = "BIOS";
        private static string EWRAM = "EWRAM";
        private static string IWRAM = "IWRAM";
        private static string ROM = "ROM";
        private uint? m_Trainer = null;
        private SimpleMemoryAddress? m_Tid = null;
        private SimpleMemoryAddress? m_Sid = null;
        public Emer_U_AddressCollection()
        {
            TrainerPointer = 0x3005D90;
            Coords = 0x2037360;
            MapBank = 0x203BC80;
            EnemyStats = 0x2024744;
            uint pstats = 0x20244EC;
            uint pcount = 0x20244E9;
            TrainerState = new SimpleMemoryAddress(TrainerPointer + 199, 1, IWRAM);
            MapId = new SimpleMemoryAddress(TrainerPointer + 200, 1, IWRAM);
            TrainerMapBank = new SimpleMemoryAddress(TrainerPointer + 201, 1, IWRAM);
            PosX = new SimpleMemoryAddress(Coords + 0, 1, EWRAM);
            PosY = new SimpleMemoryAddress(Coords + 2, 1, EWRAM);
            Facing = new SimpleMemoryAddress(Coords + 8, 1, EWRAM);
            Enemy = new ClassMemoryAddress<Mon>(EnemyStats, EWRAM);
            PartyCount = new SimpleMemoryAddress(pcount, 1, EWRAM);
            Party = new ClassMemoryAddress<MonParty>(pstats, EWRAM);
        }

        public IMemoryApi? MemoryApi { get; set; }
        public uint TrainerPointer { get; }

        public uint Coords { get; }
        public uint MapBank { get; }

        public uint EnemyStats { get; }

        public SimpleMemoryAddress TrainerState { get; }

        public SimpleMemoryAddress MapId { get; }

        public SimpleMemoryAddress TrainerMapBank { get; }

        public SimpleMemoryAddress PosX { get; }

        public SimpleMemoryAddress PosY { get; }

        public SimpleMemoryAddress Tid
        {
            get
            {
                if (m_Tid == null)
                {
                    if (MemoryApi == null)
                    {
                        throw new InvalidOperationException("Call to MemoryApi-reliant field before MemoryApi is set");
                    }
                    if (m_Trainer == null)
                    {
                        m_Trainer = MemoryApi.ReadU32(TrainerPointer & SimpleMemoryAddress.Bitmask, IWRAM);
                    }
                    m_Tid = new SimpleMemoryAddress(m_Trainer.Value + 10, 2, EWRAM);
                }

                return m_Tid;
            }
        }

        public SimpleMemoryAddress Sid
        {
            get
            {
                if (m_Sid == null)
                {
                    if (MemoryApi == null)
                    {
                        throw new InvalidOperationException("Call to MemoryApi-reliant field before MemoryApi is set");
                    }
                    if (m_Trainer == null)
                    {
                        m_Trainer = MemoryApi.ReadU32(TrainerPointer & SimpleMemoryAddress.Bitmask, IWRAM);
                    }
                    m_Sid = new SimpleMemoryAddress(m_Trainer.Value + 12, 2, EWRAM);
                }

                return m_Sid;
            }
        }

        public SimpleMemoryAddress Facing { get; }

        public ClassMemoryAddress<Mon> Enemy { get; }
        public SimpleMemoryAddress PartyCount { get; }
        public ClassMemoryAddress<MonParty> Party { get; }

        public void ResetPointedAddresses()
        {
            m_Trainer = null;
            m_Tid = null;
            m_Sid = null;
        }
    }
}
