using BizHawk.Client.Common;
using Pokebot_Sharp.MemoryAddress;
using System;

namespace Pokebot_Sharp
{
    public class Mon : IMemoryReadable
    {
        private static int[][] m_SubstructSelector = new int[][]{
        new int[]{0, 1, 2, 3},
        new int[]{0, 1, 3, 2},
        new int[]{0, 2, 1, 3},
        new int[] { 0, 3, 1, 2 },
        new int[] { 0, 2, 3, 1 },
        new int[] { 0, 3, 2, 1 },
        new int[] { 1, 0, 2, 3 },
        new int[] { 1, 0, 3, 2 },
        new int[] { 2, 0, 1, 3 },
        new int[] { 3, 0, 1, 2 },
        new int[] { 2, 0, 3, 1 },
        new int[] { 3, 0, 2, 1 },
        new int[] { 1, 2, 0, 3 },
        new int[] { 1, 3, 0, 2 },
        new int[] { 2, 1, 0, 3 },
        new int[] { 3, 1, 0, 2 },
        new int[] { 2, 3, 0, 1 },
        new int[] { 3, 2, 0, 1 },
        new int[] { 1, 2, 3, 0 },
        new int[] { 1, 3, 2, 0 },
        new int[] { 2, 1, 3, 0 },
        new int[] { 3, 1, 2, 0 },
        new int[] { 2, 3, 1, 0 },
        new int[] { 3, 2, 1, 0 },
    };
        public uint Personality { get; private set; }
        public uint MagicWord { get; private set; }
        public uint OtId { get; private set; }
        public uint Sv { get; private set; }
        public bool IsShiny { get; private set; }
        public uint Language { get; private set; }
        public bool IsBadEgg { get; private set; }
        public bool HasSpecies { get; private set; }
        public bool IsEgg { get; private set; }
        public uint Markings { get; private set; }
        public uint Status { get; private set; }
        public uint Level { get; private set; }
        public uint Mail { get; private set; }
        public uint Hp { get; private set; }
        public uint MaxHp { get; private set; }
        public uint Attack { get; private set; }
        public uint Defense { get; private set; }
        public uint Speed { get; private set; }
        public uint SpAttack { get; private set; }
        public uint SpDefense { get; private set; }
        public uint HpEv { get; private set; }
        public uint AttackEv { get; private set; }
        public uint DefenseEv { get; private set; }
        public uint SpeedEv { get; private set; }
        public uint SpAttackEv { get; private set; }
        public uint SpDefenseEv { get; private set; }
        public uint HpIv { get; private set; }
        public uint AttackIv { get; private set; }
        public uint DefenseIv { get; private set; }
        public uint SpeedIv { get; private set; }
        public uint SpAttackIv { get; private set; }
        public uint SpDefenseIv { get; private set; }
        public uint Species { get; private set; }
        public string SpeciesName { get; private set; } = string.Empty;
        public uint HeldItem { get; private set; }
        public uint Experience { get; private set; }
        public uint PpBonuses { get; private set; }
        public uint Friendship { get; private set; }
        public uint Pokerus { get; private set; }
        public uint MetLocation { get; private set; }
        public uint MetLevel { get; private set; }
        public uint MetGame { get; private set; }
        public uint Pokeball { get; private set; }
        public uint OtGender { get; private set; }
        public uint AltAbility { get; private set; }
        public uint[] Moves { get; private set; } = new uint[4];
        public uint[] Pp { get; private set; } = new uint[4];

        public Mon()
        {

        }

        public void ReadFromMemory(IMemoryApi memoryApi, long address)
        {
            Personality = MemoryHelper.Read(address, 4, memoryApi);
            OtId = MemoryHelper.Read(address + 4, 4, memoryApi);
            uint sid = OtId >> 16;
            uint tid = OtId & 0xFFFF;
            uint pH = Personality >> 16;
            uint pL = Personality & 0xFFFF;
            Sv = tid ^ sid ^ pH ^ pL;
            IsShiny = Sv < 8;
            MagicWord = Personality ^ OtId;
            Language = MemoryHelper.Read(address + 18, 1, memoryApi);
            uint flags = MemoryHelper.Read(address + 19, 1, memoryApi);
            IsBadEgg = (flags & 0b1u) != 0u;
            HasSpecies = (flags & 0b10u) != 0u;
            IsEgg = (flags & 0b100u) != 0u;
            Markings = MemoryHelper.Read(address + 27, 1, memoryApi);
            Status = MemoryHelper.Read(address + 80, 2, memoryApi);
            Level = MemoryHelper.Read(address + 84, 1, memoryApi);
            Mail = MemoryHelper.Read(address + 85, 4, memoryApi);
            Hp = MemoryHelper.Read(address + 86, 2, memoryApi);
            MaxHp = MemoryHelper.Read(address + 88, 2, memoryApi);
            Attack = MemoryHelper.Read(address + 90, 2, memoryApi);
            Defense = MemoryHelper.Read(address + 92, 2, memoryApi);
            Speed = MemoryHelper.Read(address + 94, 2, memoryApi);
            SpAttack = MemoryHelper.Read(address + 96, 2, memoryApi);
            SpDefense = MemoryHelper.Read(address + 98, 2, memoryApi);

            uint key = OtId ^ Personality;
            int[] pSel = m_SubstructSelector[Personality % 24u];

            uint[,] ss = new uint[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ss[j, i] = MemoryHelper.Read(address + 32 + pSel[j] * 12 + i * 4, 4, memoryApi) ^ key;
                }
            }

            Species = (ss[0, 0] & 0xFFFFu);
            SpeciesName = MonNames.Names[(int)(Species) % MonNames.Names.Count];
            HeldItem = ss[0, 0] >> 16;
            Experience = ss[0, 1];
            PpBonuses = ss[0, 2] & 0xFFu;
            Friendship = (ss[0, 2] >> 8) & 0xFF;
            Moves = new uint[]
            {
                ss[1,0] & 0xFFFFu,
                ss[1,0] >> 16,
                ss[1,1] & 0xFFFFu,
                ss[1,1] >> 16
            };
            Pp = new uint[]
            {
                ss[1,2] & 0xFFu,
                (ss[1,2] >> 8) & 0xFFu,
                (ss[1,2] >> 16) & 0xFFu,
                ss[1,2] >> 24
            };


            HpEv = ss[2, 0] & 0xFF;
            AttackEv = (ss[2, 0] >> 8) & 0xFF;
            DefenseEv = (ss[2, 0] >> 16) & 0xFF;
            SpeedEv = ss[2, 0] >> 24;
            SpAttackEv = ss[2, 1] & 0xFF;
            SpDefenseEv = (ss[2, 1] >> 8) & 0xFF;

            Pokerus = ss[3, 0] & 0xFF;
            MetLocation = (ss[3, 0] >> 8) & 0xFF;
            flags = ss[3, 0] >> 16;
            MetLevel = flags & 0x7F;
            MetGame = (flags >> 7) & 0xF;
            Pokeball = (flags >> 11) & 0xF;
            OtGender = (flags >> 15) & 0x1;
            flags = ss[3, 1];

            HpIv = flags & 0x1F;
            AttackIv = (flags >> 5) & 0x1F;
            DefenseIv = (flags >> 10) & 0x1F;
            SpeedIv = (flags >> 15) & 0x1F;
            SpAttackIv = (flags >> 20) & 0x1F;
            SpDefenseIv = (flags >> 25) & 0x1F;
            AltAbility = (flags >> 31) & 1;
        }

        public override string ToString()
        {
            var props = typeof(Mon).GetProperties();

            string result = string.Empty;

            foreach (var prop in props)
            {

                result += prop.Name + ": ";
                if (prop.PropertyType == typeof(uint[]))
                {
                    uint[]? values = prop.GetValue(this) as uint[];
                    if (values != null)
                    {
                        foreach (var value in values)
                        {
                            result += Environment.NewLine + value.ToString();
                        }
                    }
                } else
                {
                    result += prop.GetValue(this);
                }
                result += Environment.NewLine;
            }

            return result;
        }
    }
}
