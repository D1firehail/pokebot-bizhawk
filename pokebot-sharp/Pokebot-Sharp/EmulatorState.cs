namespace Pokebot_Sharp
{
    public enum EmulatorState
    {
        Uninitialized,
        Startup,
        StarterSelection,
        Restarting,
        Spinning,
        Battle,
        BattleRun,
        BattleCatch,
        DoNothing
    }

    public enum EmulatorMode
    {
        Disabled,
        Reporting,
        Starter,
        Spin
    }
}
