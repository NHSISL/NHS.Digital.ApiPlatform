// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------
using System;

namespace NHS.Digital.ApiPlatform.Sdk.Brokers.DateTimes
{
    internal class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTimeOffset() => DateTimeOffset.UtcNow;
    }
}
