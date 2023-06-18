using Pokebot_Sharp.Common;
using System.Collections.Generic;

namespace Pokebot_Sharp.Modes
{
    public class ModeCollection
    {
        private Dictionary<EmulatorMode, IModeExecutor> m_ModeExecutors;
        public ModeCollection(PokebotForm parentForm)
        {
            m_ModeExecutors = new Dictionary<EmulatorMode, IModeExecutor>
            {
                { EmulatorMode.Reporting, new ReportingModeExecutor(parentForm) },
                { EmulatorMode.Starter, new StarterModeExecutor(parentForm) },
                { EmulatorMode.Spin, new SpinModeExecutor(parentForm) }
            };

        }

        public void Execute(EmulatorMode mode)
        {
            if (m_ModeExecutors.TryGetValue(mode, out IModeExecutor executor))
            {
                executor.Execute();
            }
        }

        public void ResetAll()
        {
            foreach (var m in m_ModeExecutors.Values)
            {
                m.Reset();
            }
        }

        public void FullResetAll()
        {
            foreach (var m in m_ModeExecutors.Values)
            {
                m.FullReset();
            }
        }
    }
}
