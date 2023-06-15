using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using BizHawk.Emulation.Common;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Pokebot_Sharp.Common
{
    [ExternalTool("Pokebot_Sharp")]
    public sealed partial class PokebotForm : ToolFormBase, IExternalToolForm
    {
        private IAddressCollection m_AddressCollection;
        public ApiContainer? _maybeAPIContainer { get; set; }
        public EmulatorState CurrentEmulatorState { get; set; } = EmulatorState.Uninitialized;

        private EmulatorState? m_LastEmulatorState = null;

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
            CurrentEmulatorState = EmulatorState.Uninitialized;
        }

        protected override void UpdateAfter()
        {
            base.UpdateAfter();

            //Check if emulator stopped
            if (APIs.Emulation.GetGameInfo().IsNullInstance() && CurrentEmulatorState != EmulatorState.DoNothing) 
            {
                CurrentEmulatorState = EmulatorState.Uninitialized;
            }

            //Main switch for bot state
            switch (CurrentEmulatorState)
            {
                case EmulatorState.Uninitialized:
                    if (!APIs.Emulation.GetGameInfo().IsNullInstance())
                    {
                        CurrentEmulatorState = EmulatorState.Startup;
                    }
                    break;
                case EmulatorState.Startup:
                    //TODO actually determine what state to go into, maybe get past title screen?
                    CurrentEmulatorState = EmulatorState.ReadOnly;
                    break;
                case EmulatorState.ReadOnly:
                    ExecuteReadOnly();
                    break;
                case EmulatorState.DoNothing: 
                    break;
                default: 
                    throw new NotImplementedException("Unknown/Unsupported Emulator state");
            }
        }
        protected override string WindowTitleStatic => "Pokebot_Sharp";

        private void ExecuteReadOnly()
        {
            //Placeholder testing stuff
            textBox_TestOutput.Clear();
            textBox_TestOutput.AppendText("Tid: " + m_AddressCollection.Tid.Read(APIs.Memory) + Environment.NewLine);
            textBox_TestOutput.AppendText("Sid: " + m_AddressCollection.Sid.Read(APIs.Memory) + Environment.NewLine);
            textBox_TestOutput.AppendText("TrainerState: " + m_AddressCollection.TrainerState.Read(APIs.Memory) + Environment.NewLine);
            textBox_TestOutput.AppendText("MapId: " + m_AddressCollection.MapId.Read(APIs.Memory) + Environment.NewLine);
            textBox_TestOutput.AppendText("TrainerMapBank: " + m_AddressCollection.TrainerMapBank.Read(APIs.Memory) + Environment.NewLine);
            textBox_TestOutput.AppendText("PosX: " + (m_AddressCollection.PosX.Read(APIs.Memory) - 7) + Environment.NewLine);
            textBox_TestOutput.AppendText("PosY: " + (m_AddressCollection.PosY.Read(APIs.Memory) - 7) + Environment.NewLine);
            textBox_TestOutput.AppendText("Facing: " + (m_AddressCollection.Facing.Read(APIs.Memory) - 7) + Environment.NewLine);
            //Mon enemy = new Mon();
            //m_AddressCollection.Enemy.ReadInto(APIs.Memory, enemy);
            //MonParty party = new MonParty(m_AddressCollection.PartyCount);
            //m_AddressCollection.Party.ReadInto(APIs.Memory, party);
        }

        public Bitmap TakeScreenshot()
        {
            //Uses Reflection to find and access the screenshot function
            FieldInfo[] fieldInfos = APIs.Comm.MMF.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Func<byte[]>? screenshotCallback = null;
            foreach (var field in fieldInfos)
            {
                if (field.FieldType == typeof(Func<byte[]>) && field.Name.Contains("takeScreenshotCallback"))
                {
                    screenshotCallback = field.GetValue(APIs.Comm.MMF) as Func<byte[]>;
                }
            }
            if (screenshotCallback != null)
            {
                byte[] imgBytes = screenshotCallback();
                Bitmap? img = null;
                using (var imgStream = new MemoryStream(imgBytes))
                {
                    img = new Bitmap(imgStream);
                }
                return img;
            }
            throw new InvalidOperationException("Some required condition for screenshotting not met");
        }

        private void btn_MasterToggle_Click(object sender, EventArgs e)
        {
            if (m_LastEmulatorState == null)
            {
                m_LastEmulatorState = CurrentEmulatorState;
                CurrentEmulatorState = EmulatorState.DoNothing;
            } else
            {
                CurrentEmulatorState = m_LastEmulatorState.Value;
                m_LastEmulatorState = null;
            }
        }

        private void btn_Screenshot_Click(object sender, EventArgs e)
        {
            if (!APIs.Emulation.GetGameInfo().IsNullInstance())
            {
                string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ssff");
                Bitmap img = TakeScreenshot();
                string myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                img.Save(myPictures + "\\BizScreenshot-" + timestamp + ".png");
                Process.Start("explorer.exe", myPictures);
            }
        }
    }
}
