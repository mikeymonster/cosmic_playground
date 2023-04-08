using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Services;

namespace Cosmic.Playground.UnitTests.Core.Services;

public class CallStuffTests
{
    [Fact]
    public async Task CallSomething_Calls_Target()
    {
        var callTarget = Substitute.For<ICallableThing>();
        var service = new SomeClass(callTarget);

        await service.CallSomething();

        await callTarget
            .Received(1)
            .DoStuff();
    }
}