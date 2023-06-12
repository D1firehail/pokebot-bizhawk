using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using BizHawk.Emulation.Common;
using System;
using System.Net;
using System.Threading;

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


        public MemoryApi MemAPI { get; set; }

        public PokebotForm() 
        {
            InitializeComponent();
            m_AddressCollection = new Emer_U_AddressCollection();
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
                textBox_TestOutput.AppendText("PosX: " + (ReadSingleAddress(m_AddressCollection.PosX) - 7) + Environment.NewLine);
                textBox_TestOutput.AppendText("PosY: " + (ReadSingleAddress(m_AddressCollection.PosY) - 7) + Environment.NewLine);
                //Thread.Sleep(10);
            }
        }
        protected override string WindowTitleStatic => "Pokebot_Sharp";

        private void btn_MasterToggle_Click(object sender, System.EventArgs e)
        {
            m_BotEnabled = !m_BotEnabled;
        }

        private uint ReadSingleAddress(MemoryAddress address)
        {
            //long addr = address.StartAddress & 0xFFFFFF;
            //long shifted = (addr >> 16);
            //string? domain = shifted switch
            //{
            //    0 => "BIOS",
            //    2 => "EWRAM",
            //    3 => "IWRAM",
            //    8 => "ROM",
            //    _ => null
            //};
            return APIs.Memory.ReadU8(address.StartAddress, address.Domain);
        }
    }
}
