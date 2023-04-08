using Cosmic.Playground.Core.DataGenerators;
using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.UnitTests.Core.Builders;
public static class FakeDataGeneratorBuilder
{
    public static FakeDataGenerator Build(
        IDateTimeProvider? dateTimeProvider = null)
    {
        dateTimeProvider ??= Substitute.For<IDateTimeProvider>();

        return new FakeDataGenerator(dateTimeProvider);
    }
}
