namespace Pokebot_Sharp.Modes
{
    public interface IModeExecutor
    {
        public void Execute();
        public void Reset();
        public void FullReset();
    }
}
