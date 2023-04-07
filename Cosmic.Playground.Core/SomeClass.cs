using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.Core;
public class SomeClass : ICallingThing
{
    private readonly ICallableThing _thing2;

    public SomeClass(ICallableThing thing2)
    {
        _thing2 = thing2 ?? throw new ArgumentNullException(nameof(thing2));
    }

    public async Task CallSomething()
    {
        await _thing2.DoStuff();
    }
}
