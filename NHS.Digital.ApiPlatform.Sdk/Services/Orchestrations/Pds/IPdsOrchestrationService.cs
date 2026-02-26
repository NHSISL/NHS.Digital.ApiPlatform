// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NHS.Digital.ApiPlatform.Sdk.Services.Orchestrations.Pds
{
    public interface IPdsOrchestrationService
    {
        ValueTask<string> SearchPatientsAsync(
            string family,
            IEnumerable<string>? given = null,
            string? gender = null,
            DateOnly? birthdate = null,
            CancellationToken cancellationToken = default);
    }
}
