using BizHawk.Client.Common;
using Pokebot_Sharp.Common;

namespace Pokebot_Sharp.Modes
{
    public class StarterModeExecutor : IModeExecutor
    {
        private readonly PokebotForm m_Form;
        private ApiContainer APIs => m_Form._maybeAPIContainer!;
        private bool m_FlipFlop = false;
        private uint m_FrameCount = 0;
        private uint m_TargetFrame = DefaultTargetFrame;
        private const uint DefaultTargetFrame = 100;
        public StarterModeExecutor(PokebotForm form)
        {
            m_Form = form;
        }

        public void Execute()
        {
            switch (m_Form.CurrentEmulatorState)
            {
                case EmulatorState.Startup:
                    DoStartup();
                    break;
                case EmulatorState.StarterSelection:
                    DoStarterSelection();
                    break;
                default:
                    break;
            }
        }

        public void SetTargetFrame(uint targetFrame)
        {
            m_TargetFrame = targetFrame;
        }

        public void Reset()
        {
            m_FlipFlop = false;
            m_FrameCount = 0;
            //intentionally not resetting m_TargetFrame
        }

        public void FullReset()
        {
            //same as Reset, but also doing m_TargetFrame
            m_TargetFrame = DefaultTargetFrame;
            Reset();
        }

        private void DoStarterSelection()
        {
            m_FrameCount++;
            uint trainerState = m_Form.AddressCollection.TrainerState.Read(APIs.Memory);
            string flipFlopButton = string.Empty;


            if (trainerState != 255)
            {
                flipFlopButton = "A";
            }
            else
            {
                //make sure A is no longer pressed
                APIs.Joypad.Set("A", false);
                int direction = m_Form.TargetStarter; //left, center or right

                if (direction < 0)
                {
                    flipFlopButton = "Left";
                }
                else if (direction > 0)
                {
                    flipFlopButton = "Right";
                }
                //no need to set button for center
            }

            if (m_FrameCount >= m_TargetFrame)
            {
                //un-toggle left/right if we're about to hit target frame
                APIs.Joypad.Set(flipFlopButton, false);
                flipFlopButton = "A";
            }

            if (m_FrameCount == m_TargetFrame)
            {
                //sync flip flop
                m_FlipFlop = false;
            }
            APIs.Joypad.Set(flipFlopButton, m_FlipFlop);
            m_FlipFlop = !m_FlipFlop;


            //if we're above target frame, wait for a pokemon to appear in our party and choose what to do
            if (m_FrameCount > m_TargetFrame)
            {
                MonParty party = new MonParty(m_Form.AddressCollection.PartyCount);
                m_Form.AddressCollection.Party.ReadInto(APIs.Memory, party);
                if (party.Mons.Count > 0)
                {
                    string monString = party.Mons[0].ToString();
                    string customParams = m_Form.textBox_TargetParams.Text;
                    //if no params given, just check if it's shiny
                    if (party.Mons[0].IsShiny && string.IsNullOrEmpty(customParams))
                    {
                        //manual intervention for now
                        m_Form.CurrentEmulatorState = EmulatorState.DoNothing;
                    }
                    else
                    {
                        //split custom params into a list and check that the monString contains each of them
                        string[] paramList = customParams.Split(new char[] { '/' });
                        bool passesCustom = true;
                        foreach (var item in paramList)
                        {
                            if (!monString.Contains(item.Trim()))
                            {
                                passesCustom = false;
                                break;
                            }
                        }

                        //if monString contains every custom parameter, await manual input. Otherwise, do nothing
                        if (passesCustom && !string.IsNullOrEmpty(customParams))
                        {
                            m_Form.CurrentEmulatorState = EmulatorState.DoNothing;
                        } 
                        else
                        {
                            //restart, targeting 1 frame later
                            m_TargetFrame++;
                            m_Form.numericUpDown_TargetFrame.Value = m_TargetFrame;
                            m_Form.CurrentEmulatorState = EmulatorState.Restarting;
                        }
                    }

                    m_Form.DisplayMessage(monString, true);

                    //make sure A is no longer pressed after the starter has been chosen
                    APIs.Joypad.Set("A", false);
                }
            }

        }

        private void DoStartup()
        {
            var sniffer = m_Form.AddressCollection.StartScreenSniffer.Read(APIs.Memory);

            //Spam A to get past the opening screen
            APIs.Joypad.Set("A", m_FlipFlop);
            m_FlipFlop = !m_FlipFlop;

            if (sniffer != 0)
            {
                m_Form.AddressCollection.ResetPointedAddresses();

                uint trainerState = m_Form.AddressCollection.TrainerState.Read(APIs.Memory);

                if (trainerState == 0)
                {
                    //New game. This wasn't intended. Freeze
                    m_Form.CurrentEmulatorState = EmulatorState.DoNothing;
                    APIs.Joypad.Set("A", false);
                }
                else if (trainerState == 80)
                {
                    //We're in-game now

                    m_Form.CurrentEmulatorState = EmulatorState.StarterSelection;
                    APIs.Joypad.Set("A", false);
                }

            }
        }
    }
}
