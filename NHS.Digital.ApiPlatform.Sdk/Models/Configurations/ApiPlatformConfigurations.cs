// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace NHS.Digital.ApiPlatform.Sdk.Models.Configurations
{
    public class ApiPlatformConfigurations
    {
        public CareIdentityConfigurations CareIdentity { get; set; } = new();
        public PersonalDemographicsServiceConfigurations PersonalDemographicsService { get; set; } = new();
    }
}