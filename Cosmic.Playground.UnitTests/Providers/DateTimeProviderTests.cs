using Cosmic.Playground.Core.Providers;

namespace Cosmic.Playground.UnitTests.Providers;

public class DateTimeProviderTests
{
    [Fact]
    public void DateTimeProvider_Generates_DateTime_Now()
    {
        var before = DateTime.Now;
        var result = new DateTimeProvider().Now;
        var after = DateTime.Now;

        result.Should().NotBeBefore(before);
        result.Should().NotBeAfter(after);
        result.Kind.Should().Be(DateTimeKind.Local);
    }

    [Fact]
    public void DateTimeProvider_Generates_DateTime_UtcNow()
    {
        var before = DateTime.UtcNow;
        var result = new DateTimeProvider().UtcNow;
        var after = DateTime.UtcNow;

        result.Should().NotBeBefore(before);
        result.Should().NotBeAfter(after);
        result.Kind.Should().Be(DateTimeKind.Utc);
    }

    [Fact]
    public void DateTimeProvider_Generates_DateTime_Today()
    {
        var before = DateTime.Today;
        var result = new DateTimeProvider().Today;
        var after = DateTime.Today;

        result.Should().NotBeBefore(before);
        result.Should().NotBeAfter(after);
        result.Kind.Should().Be(DateTimeKind.Local);
    }
}

