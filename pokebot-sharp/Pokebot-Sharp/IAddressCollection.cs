using BizHawk.Client.Common;

namespace Pokebot_Sharp
{
    public interface IAddressCollection
    {
        public uint TrainerPointer { get; }
        public uint Coords { get; }
        public uint MapBank { get; }

        /// <summary>
        /// Resets any addresses that depend on pointer structures, for example Trainer/Secret ID.
        /// </summary>
        public void ResetPointedAddresses();
        public IMemoryApi? MemoryApi { get; set; }
        public SimpleMemoryAddress Tid { get; }
        public SimpleMemoryAddress Sid { get; }
        public SimpleMemoryAddress TrainerState { get; }
        public SimpleMemoryAddress MapId { get; }
        public SimpleMemoryAddress TrainerMapBank { get; }
        public SimpleMemoryAddress PosX { get; }
        public SimpleMemoryAddress PosY { get; }
        public SimpleMemoryAddress Facing { get; }
        public ClassMemoryAddress<Mon> Enemy { get; }
        public SimpleMemoryAddress PartyCount { get; }
        public ClassMemoryAddress<MonParty> Party { get; }

    }
}
