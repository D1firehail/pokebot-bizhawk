using Pokebot_Sharp.Common;
using System.Collections.Generic;

namespace Pokebot_Sharp.Modes
{
    public class ModeCollection
    {
        public Dictionary<EmulatorMode, IModeExecutor> ModeExecutors { get; private set; }
        public ModeCollection(PokebotForm parentForm)
        {
            ModeExecutors = new Dictionary<EmulatorMode, IModeExecutor>
            {
                { EmulatorMode.Reporting, new ReportingModeExecutor(parentForm) },
                { EmulatorMode.Starter, new StarterModeExecutor(parentForm) },
                { EmulatorMode.Spin, new SpinModeExecutor(parentForm) }
            };

        }

        public void Execute(EmulatorMode mode)
        {
            if (ModeExecutors.TryGetValue(mode, out IModeExecutor executor))
            {
                executor.Execute();
            }
        }

        public void ResetAll()
        {
            foreach (var m in ModeExecutors.Values)
            {
                m.Reset();
            }
        }

        public void FullResetAll()
        {
            foreach (var m in ModeExecutors.Values)
            {
                m.FullReset();
            }
        }
    }
}
