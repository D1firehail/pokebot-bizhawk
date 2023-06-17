namespace Pokebot_Sharp
{
    public enum EmulatorState
    {
        Uninitialized,
        Startup,
        StarterSelection,
        Restarting,
        DoNothing
    }

    public enum EmulatorMode
    {
        Disabled,
        Reporting,
        Starter
    }
}
