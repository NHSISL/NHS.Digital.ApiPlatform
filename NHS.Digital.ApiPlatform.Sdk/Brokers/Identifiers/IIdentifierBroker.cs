// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------
using System;

namespace NHS.Digital.ApiPlatform.Sdk.Brokers.Identifiers
{
    public interface IIdentifierBroker
    {
        Guid GetNewGuid();
    }
}
