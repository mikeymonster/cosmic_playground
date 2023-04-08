using Cosmic.Playground.Core.DataGenerators;
using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.UnitTests.Core.Builders;
public static class FakeDataGeneratorBuilder
{
    public static FakeDataGenerator Build(
        IDateTimeProvider? dateTimeProvider = null,
        IGuidProvider? guidProvider = null)
    {
        dateTimeProvider ??= Substitute.For<IDateTimeProvider>();
        guidProvider ??= Substitute.For<IGuidProvider>();

        return new FakeDataGenerator(dateTimeProvider, guidProvider);
    }
}
