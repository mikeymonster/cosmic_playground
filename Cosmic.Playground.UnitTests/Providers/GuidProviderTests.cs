﻿using Cosmic.Playground.Core.Providers;
using FluentAssertions;

namespace Cosmic.Playground.UnitTests.Providers;

public class GuidProviderTests
{
    [Fact]
    public void GuidProvider_Generates_New_Guid()
    {
        var result = new GuidProvider().NewGuid();

        result.Should().NotBeEmpty();
    }
}
