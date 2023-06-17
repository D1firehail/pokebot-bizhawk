using BizHawk.Client.Common;

namespace Pokebot_Sharp.MemoryAddress
{
    public class PointedMemoryAddess : SimpleMemoryAddress
    {
        public SimpleMemoryAddress Pointer { get; protected set; }
        public long Offset { get; protected set; }
        public bool PointerSet { get; protected set; }
        public PointedMemoryAddess(SimpleMemoryAddress pointer, int length, long offset = 0) : base()
        {
            Length = length;
            Domain = pointer.Domain;
            Pointer = pointer;
            Offset = offset;
            PointerSet = false;
        }

        public void ResetPointer()
        {
            PointerSet = false;

            if (Pointer is PointedMemoryAddess pointedPointer)
            {
                pointedPointer.ResetPointer();
            }
        }

        public override uint Read(IMemoryApi memoryApi)
        {
            if (!PointerSet)
            {
                StartAddress = Pointer.Read(memoryApi) + Offset;
                SetDomain(StartAddress);
                PointerSet = true;
            }
            return base.Read(memoryApi);
        }
    }
}
