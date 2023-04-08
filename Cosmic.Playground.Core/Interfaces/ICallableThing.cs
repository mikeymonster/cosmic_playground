namespace Cosmic.Playground.Core.Interfaces;

public interface ICallableThing
{
    Task DoStuff();

    void DisplayMessage(string message);
}