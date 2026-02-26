// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using NHS.Digital.ApiPlatform.Sdk.Clients.CareIdentityServices;
using NHS.Digital.ApiPlatform.Sdk.Clients.PersonalDemographicsServices;

namespace NHS.Digital.ApiPlatform.Sdk.Clients.ApiPlatforms
{
    public interface IApiPlatformClient
    {
        ICareIdentityServiceClient CareIdentityServiceClient { get; }
        IPersonalDemographicsServiceClient PersonalDemographicsServiceClient { get; }
    }
}
