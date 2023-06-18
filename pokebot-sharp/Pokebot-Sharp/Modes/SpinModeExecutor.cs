using BizHawk.Client.Common;
using Pokebot_Sharp.Common;

namespace Pokebot_Sharp.Modes
{
    public class SpinModeExecutor : IModeExecutor
    {
        private readonly PokebotForm m_Form;
        private bool m_FlipFlop = false;
        private ApiContainer APIs => m_Form._maybeAPIContainer!;
        public SpinModeExecutor(PokebotForm form)
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
                case EmulatorState.Spinning:
                    DoSpinning();
                    break;
                case EmulatorState.Battle:
                    DoBattle();
                    break;
                case EmulatorState.BattleRun:
                    DoBattleRun();
                    break;
                default:
                    break;
            }
        }

        public void Reset()
        {
            m_FlipFlop = false;
        }

        public void FullReset() => Reset();

        private void DoBattleRun()
        {
            
            uint trainerState = m_Form.AddressCollection.TrainerState.Read(APIs.Memory);
            bool inBattleState = trainerState <= 3;
            uint cursor = m_Form.AddressCollection.BattleCursor.Read(APIs.Memory);
            //0->Fight
            //1->Bag
            //2->Pokemon
            //3->Run

            //menu navigation
            APIs.Joypad.Set("Right", (cursor == 0 || cursor == 2) && inBattleState && m_FlipFlop);
            APIs.Joypad.Set("Down", cursor == 1 && inBattleState && m_FlipFlop);

            //Mash A as long as we're on Run and still in battle state
            APIs.Joypad.Set("A", m_FlipFlop && cursor == 3 && inBattleState);
            m_FlipFlop = !m_FlipFlop;

            if (!inBattleState)
            {
                //we're out of battle, return to spinning
                m_FlipFlop = false;
                m_Form.CurrentEmulatorState = EmulatorState.Spinning;
            }
        }

        private void DoBattle()
        {
            uint trainerState = m_Form.AddressCollection.TrainerState.Read(APIs.Memory);
            if (trainerState > 3)
            {
                //if we're not in battle state yet, mash B to get past the beginning text
                APIs.Joypad.Set("B", m_FlipFlop);
                m_FlipFlop = !m_FlipFlop;
            } 
            else
            {
                APIs.Joypad.Set("B", false);
                m_FlipFlop = false;
                //time to check if we want to catch the opponent, or just run away
                Mon enemy = new Mon();
                m_Form.AddressCollection.Enemy.ReadInto(APIs.Memory, enemy);
                if (enemy.IsShiny)
                {
                    //not implemented yet
                    m_Form.CurrentEmulatorState = EmulatorState.BattleCatch;
                } 
                else
                {
                    m_Form.CurrentEmulatorState = EmulatorState.BattleRun;
                }
            }
        }

        private void DoSpinning()
        {
            uint trainerState = m_Form.AddressCollection.TrainerState.Read(APIs.Memory);
            bool hasNoEncounter = trainerState == 80;
            uint direction = m_Form.AddressCollection.Facing.Read(APIs.Memory);

            //spin clockwise, based on current direction
            APIs.Joypad.Set("Up", direction == 51 && hasNoEncounter);
            APIs.Joypad.Set("Right", direction == 34 && hasNoEncounter);
            APIs.Joypad.Set("Down", direction == 68 && hasNoEncounter);
            APIs.Joypad.Set("Left", direction == 17 && hasNoEncounter);

            if (!hasNoEncounter)
            {
                //we have an encounter
                m_Form.CurrentEmulatorState = EmulatorState.Battle;
            }
        }

        private void DoStartup()
        {
            var sniffer = m_Form.AddressCollection.StartScreenSniffer.Read(APIs.Memory);

            if (sniffer != 0)
            {
                m_Form.AddressCollection.ResetPointedAddresses();

                uint trainerState = m_Form.AddressCollection.TrainerState.Read(APIs.Memory);

                if (trainerState == 80)
                {
                    //enter spin mode once we're in the normal state
                    m_Form.CurrentEmulatorState = EmulatorState.Spinning;
                }

            }
        }
    }
}
