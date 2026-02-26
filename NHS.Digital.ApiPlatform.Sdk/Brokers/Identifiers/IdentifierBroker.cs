// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------
using System;

namespace NHS.Digital.ApiPlatform.Sdk.Brokers.Identifiers
{
    internal sealed class IdentifierBroker : IIdentifierBroker
    {
        public Guid GetNewGuid() => Guid.NewGuid();
    }
}
