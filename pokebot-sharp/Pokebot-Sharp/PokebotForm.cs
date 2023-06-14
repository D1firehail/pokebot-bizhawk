using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using System;

namespace Pokebot_Sharp.Common
{
    [ExternalTool("Pokebot_Sharp")]
    public sealed partial class PokebotForm : ToolFormBase, IExternalToolForm
    {
        private bool m_BotEnabled = false;
        private IAddressCollection m_AddressCollection;
        public ApiContainer? _maybeAPIContainer { get; set; }

        private ApiContainer APIs
            => _maybeAPIContainer!;


        public PokebotForm()
        {
            InitializeComponent();
            m_AddressCollection = new Emer_U_AddressCollection();
        }

        public override void Restart()
        {
            base.Restart();
            m_AddressCollection.MemoryApi = APIs.Memory;
            m_AddressCollection.ResetPointedAddresses();
        }

        private void LogCallback(string message)
        {
            Console.WriteLine(message);
        }

        protected override void UpdateAfter()
        {
            base.UpdateAfter();
            if (m_BotEnabled)
            {
                //long raw = 33685504L;
                //long addr = raw & 0xFFFFFF;
                //long shifted = (addr >> 16);
                //string? domain = shifted switch
                //{
                //    0 => "BIOS",
                //    2 => "EWRAM",
                //    3 => "IWRAM",
                //    8 => "ROM",
                //    _ => null
                //};


                //uint value = APIs.Memory.ReadU16(addr, domain);

                //return;
                textBox_TestOutput.Clear();
                textBox_TestOutput.AppendText("Tid: " + m_AddressCollection.Tid.Read(APIs.Memory) + Environment.NewLine);
                textBox_TestOutput.AppendText("Sid: " + m_AddressCollection.Sid.Read(APIs.Memory) + Environment.NewLine);
                textBox_TestOutput.AppendText("TrainerState: " + m_AddressCollection.TrainerState.Read(APIs.Memory) + Environment.NewLine);
                textBox_TestOutput.AppendText("MapId: " + m_AddressCollection.MapId.Read(APIs.Memory) + Environment.NewLine);
                textBox_TestOutput.AppendText("TrainerMapBank: " + m_AddressCollection.TrainerMapBank.Read(APIs.Memory) + Environment.NewLine);
                textBox_TestOutput.AppendText("PosX: " + (m_AddressCollection.PosX.Read(APIs.Memory) - 7) + Environment.NewLine);
                textBox_TestOutput.AppendText("PosY: " + (m_AddressCollection.PosY.Read(APIs.Memory) - 7) + Environment.NewLine);
                textBox_TestOutput.AppendText("Facing: " + (m_AddressCollection.Facing.Read(APIs.Memory) - 7) + Environment.NewLine);
                Mon enemy = new Mon();
                m_AddressCollection.Enemy.ReadInto(APIs.Memory, enemy);
                MonParty party = new MonParty(m_AddressCollection.PartyCount);
                m_AddressCollection.Party.ReadInto(APIs.Memory, party);
                //Thread.Sleep(10);
            }
        }
        protected override string WindowTitleStatic => "Pokebot_Sharp";

        private void btn_MasterToggle_Click(object sender, System.EventArgs e)
        {
            m_BotEnabled = !m_BotEnabled;
        }
    }
}
