using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using BizHawk.Emulation.Common;
using Pokebot_Sharp.AddressCollection;
using Pokebot_Sharp.Modes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace Pokebot_Sharp.Common
{
    [ExternalTool("Pokebot_Sharp")]
    public sealed partial class PokebotForm : ToolFormBase, IExternalToolForm
    {
        private bool m_Enabled = false;
        private bool m_EventsAdded = false;
        private ApiContainer APIs
            => _maybeAPIContainer!;
        private ModeCollection m_Modes;

        private int m_PowerCounter = 0;

        protected override string WindowTitleStatic => "Pokebot_Sharp";

        public int TargetStarter { get; private set; } = 0;
        public IAddressCollection AddressCollection { get; private set; }
        public ApiContainer? _maybeAPIContainer { get; set; }
        public EmulatorState CurrentEmulatorState { get; set; } = EmulatorState.Uninitialized;
        public EmulatorMode Mode { get; set; } = EmulatorMode.Starter;

        public PokebotForm()
        {
            InitializeComponent();
            AddressCollection = new Emer_U_AddressCollection();
            m_Modes = new ModeCollection(this);
        }
        private void OnBeforeQuickLoad(object sender, BeforeQuickLoadEventArgs e)
        {
            AddressCollection.ResetPointedAddresses();
            m_Modes.ResetAll();
            CurrentEmulatorState = EmulatorState.Uninitialized;
            APIs.Joypad.Set("Power", false);
            m_PowerCounter = 0;
        }
        private void LocalRestart()
        {
            AddressCollection.ResetPointedAddresses();
            m_Modes.ResetAll();
            CurrentEmulatorState = EmulatorState.Uninitialized;
            APIs.Joypad.Set("Power", false);
            m_PowerCounter = 0;
            if (!m_EventsAdded)
            {
                APIs.EmuClient.BeforeQuickLoad += OnBeforeQuickLoad;
                m_EventsAdded = true;
            }
        }
        public override void Restart()
        {
            base.Restart();
            LocalRestart();
            m_Modes.FullResetAll();
        }

        protected override void UpdateAfter()
        {
            //Main loop, states are checked and actions taken after every game frame
            base.UpdateAfter();
            if (!m_Enabled)
            {
                return;
            }

            if (APIs.Emulation.GetGameInfo().IsNullInstance())
            {
                //Check if emulator stopped, to avoid illegal reads
                CurrentEmulatorState = EmulatorState.Uninitialized;
            }
            else if (CurrentEmulatorState == EmulatorState.Uninitialized)
            {
                //We were uninitialized, but an emulator/game is running. Time to start up again
                CurrentEmulatorState = EmulatorState.Startup;
            }

            if (CurrentEmulatorState == EmulatorState.Restarting)
            {
                //hold power button for a second
                if (m_PowerCounter < 60)
                {
                    APIs.Joypad.Set("Power", true);
                    m_PowerCounter++;
                }
                else
                {
                    LocalRestart();
                }
                return;
            }

            //m_Modes.Execute(EmulatorMode.Reporting); //for development purposes
            m_Modes.Execute(Mode);
        }

        public void DisplayMessage(string message, bool clear)
        {
            if (clear)
            {
                textBox_TestOutput.Clear();
            }

            textBox_TestOutput.AppendText(message);
        }

        public byte[] TakeScreenshot()
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
                return screenshotCallback();
            }
            throw new InvalidOperationException("Some required condition for screenshotting not met");
        }


        private void btn_MasterToggle_Click(object sender, EventArgs e)
        {
            m_Enabled = !m_Enabled;
        }

        private void btn_Screenshot_Click(object sender, EventArgs e)
        {
            if (!APIs.Emulation.GetGameInfo().IsNullInstance())
            {
                string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ssff");
                byte[] imgBytes = TakeScreenshot();
                Bitmap img = ImageHelper.GetBitmapFromBytes(imgBytes);
                string myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                img.Save(myPictures + "\\BizScreenshot-" + timestamp + ".png");
                Process.Start("explorer.exe", myPictures);
            }
        }

        #region starter radio buttons
        private void radio_Middle_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Middle.Checked)
            {
                TargetStarter = 0;
            }
        }

        private void radio_Left_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Left.Checked)
            {
                TargetStarter = -1;
            }
        }

        private void radio_Right_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Right.Checked)
            {
                TargetStarter = 1;
            }
        }
        #endregion
    }
}
