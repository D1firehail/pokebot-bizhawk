using BizHawk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokebot_Sharp
{
    public class Emer_U_AddressCollection : IAddressCollection
    {
        private static string BIOS = "BIOS";
        private static string EWRAM = "EWRAM";
        private static string IWRAM = "IWRAM";
        private static string ROM = "ROM";
        public Emer_U_AddressCollection()
        {
            TrainerPointer = 0x3005D90;
            Coords = 0x2037360;
            TrainerState = new MemoryAddress(TrainerPointer + 199, 1);
            MapId = new MemoryAddress(TrainerPointer + 200, 1);
            MapBank = new MemoryAddress(TrainerPointer + 201, 1);
            PosX = new MemoryAddress(Coords + 0, 1, EWRAM);
            PosY = new MemoryAddress(Coords + 2, 1, EWRAM);
        }

        public int TrainerPointer { get; }

        public int Coords { get; }

        public MemoryAddress TrainerState { get; }

        public MemoryAddress MapId { get; }

        public MemoryAddress MapBank { get; }

        public MemoryAddress PosX { get; }

        public MemoryAddress PosY { get; }
    }
}
