﻿// ReSharper disable UnusedMember.Global

namespace Cosmic.Playground.Core.Interfaces;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
    DateTime Today { get; }

    DateTimeOffset NowOffset { get; }
    DateTimeOffset UtcNowOffset { get; }
}