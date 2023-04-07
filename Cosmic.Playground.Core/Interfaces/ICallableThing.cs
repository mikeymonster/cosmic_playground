namespace Cosmic.Playground.Core.Interfaces;

public interface ICallableThing
{
    public Task DoStuff();

    void DisplayMessage(string message);
}