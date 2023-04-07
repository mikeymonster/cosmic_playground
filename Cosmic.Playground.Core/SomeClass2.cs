using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.Core;
public class SomeClass2 : ICallableThing
{
    public async Task DoStuff()
    {
        Console.WriteLine("Hello World!");
    }
}
