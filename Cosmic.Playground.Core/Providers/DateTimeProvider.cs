﻿using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.Core.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Today => DateTime.Today;

    public DateTimeOffset NowOffset => DateTimeOffset.Now;
    public DateTimeOffset UtcNowOffset => DateTimeOffset.UtcNow;
}