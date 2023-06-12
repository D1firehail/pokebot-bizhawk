using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokebot_Sharp
{
    public interface IAddressCollection
    {
        public int TrainerPointer { get; }
        public int Coords{ get; }

        public MemoryAddress TrainerState{ get; }
        public MemoryAddress MapId { get; }
        public MemoryAddress MapBank{ get; }
        public MemoryAddress PosX{ get; }
        public MemoryAddress PosY{ get; }
    }
}
