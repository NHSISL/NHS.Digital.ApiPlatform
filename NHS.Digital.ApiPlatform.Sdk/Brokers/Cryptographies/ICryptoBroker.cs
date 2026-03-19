// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace NHS.Digital.ApiPlatform.Sdk.Brokers.Cryptographies
{
    public interface ICryptoBroker
    {
        string CreateUrlSafeState(int bytes = 32);
    }
}
