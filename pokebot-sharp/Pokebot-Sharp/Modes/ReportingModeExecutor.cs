
using BizHawk.Client.Common;
using Pokebot_Sharp.Common;
using System;

namespace Pokebot_Sharp.Modes
{
    public class ReportingModeExecutor : IModeExecutor
    {
        private readonly PokebotForm m_Form;
        private int m_FrameCounter = 0;
        private ApiContainer APIs => m_Form._maybeAPIContainer!;
        public ReportingModeExecutor(PokebotForm form)
        {
            m_Form = form;
        }

        public void Execute()
        {
            if (m_FrameCounter > 120)
            {
                //reset pointers every 120 frames (2 seconds) to avoid long-term reporting errors
                m_Form.AddressCollection.ResetPointedAddresses();
                m_FrameCounter = 0;
            }

            if (m_Form.CurrentEmulatorState == EmulatorState.Uninitialized)
            {
                return;
            }

            string output = "";
            output += ("Tid: " + m_Form.AddressCollection.Tid.Read(APIs.Memory) + Environment.NewLine);
            output += ("Sid: " + m_Form.AddressCollection.Sid.Read(APIs.Memory) + Environment.NewLine);
            output += ("TrainerState: " + m_Form.AddressCollection.TrainerState.Read(APIs.Memory) + Environment.NewLine);
            output += ("MapId: " + m_Form.AddressCollection.MapId.Read(APIs.Memory) + Environment.NewLine);
            output += ("TrainerMapBank: " + m_Form.AddressCollection.TrainerMapBank.Read(APIs.Memory) + Environment.NewLine);
            output += ("PosX: " + (m_Form.AddressCollection.PosX.Read(APIs.Memory) - 7) + Environment.NewLine);
            output += ("PosY: " + (m_Form.AddressCollection.PosY.Read(APIs.Memory) - 7) + Environment.NewLine);
            output += ("Facing: " + m_Form.AddressCollection.Facing.Read(APIs.Memory) + Environment.NewLine);
            output += ("PosY: " + (m_Form.AddressCollection.PosY.Read(APIs.Memory) - 7) + Environment.NewLine);
            output += ("StartSniffer: " + m_Form.AddressCollection.StartScreenSniffer.Read(APIs.Memory) + Environment.NewLine);
            output += ("PartyCount: " + m_Form.AddressCollection.PartyCount.Read(APIs.Memory) + Environment.NewLine);
            output += ("BattleCursor: " + m_Form.AddressCollection.BattleCursor.Read(APIs.Memory) + Environment.NewLine);
            m_Form.DisplayMessage(output, true);
            //Mon enemy = new Mon();
            //m_Form.AddressCollection.Enemy.ReadInto(APIs.Memory, enemy);
            //MonParty party = new MonParty(m_Form.AddressCollection.PartyCount);
            //m_Form.AddressCollection.Party.ReadInto(APIs.Memory, party);

            m_FrameCounter++;
        }

        public void Reset()
        {
            m_FrameCounter = 0;
        }

        public void FullReset() => Reset();
    }
}
