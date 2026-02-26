// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NHS.Digital.ApiPlatform.Sdk.Brokers.Storages;
using NHS.Digital.ApiPlatform.Sdk.Models.Orchestrations.Pds.Exceptions;
using NHS.Digital.ApiPlatform.Sdk.Services.Foundations.CareIdentityServices;
using NHS.Digital.ApiPlatform.Sdk.Services.Foundations.Pds;

namespace NHS.Digital.ApiPlatform.Sdk.Services.Orchestrations.Pds
{
    internal sealed partial class PdsOrchestrationService : IPdsOrchestrationService
    {
        private readonly ICareIdentityService careIdentityService;
        private readonly IPdsService pdsService;
        private readonly IApiPlatformTokenBroker tokenBroker;

        public PdsOrchestrationService(ICareIdentityService careIdentityService, IPdsService pdsService, IApiPlatformTokenBroker tokenBroker)
        {
            this.careIdentityService = careIdentityService;
            this.pdsService = pdsService;
            this.tokenBroker = tokenBroker;
        }

        public ValueTask<string> SearchPatientsAsync(
            string family,
            IEnumerable<string> given = null,
            string gender = null,
            DateOnly? birthdate = null,
            CancellationToken cancellationToken = default) =>
            TryCatch(async () =>
            {
                ValidateOnSearchPatientsAsync(family, given, gender, birthdate);
                string accessToken = await this.careIdentityService.GetAccessTokenAsync(cancellationToken);

                if (string.IsNullOrWhiteSpace(accessToken))
                {
                    throw new UnauthorizedPdsOrchestrationException("Unauthorized - Unable to retrieve access token.");
                }

                return await this.pdsService
                    .SearchPatientsAsync(accessToken, family, given, gender, birthdate, cancellationToken);
            });
    }
}
