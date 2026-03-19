// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Microsoft.Extensions.Configuration;
using NHS.Digital.ApiPlatform.Sdk.Clients.ApiPlatforms;
using NHS.Digital.ApiPlatform.Sdk.Clients.CareIdentityServices;
using NHS.Digital.ApiPlatform.Sdk.Models.Configurations;
using Xunit.Abstractions;

namespace NHS.Digital.ApiPlatform.Sdk.Tests.Integration
{
    public partial class NhsLoginTests
    {
        private readonly ICareIdentityServiceClient careIdentityServiceClient;
        private readonly ApiPlatformConfigurations apiPlatformConfigurations;
        private readonly IConfiguration configuration;
        private readonly ITestOutputHelper output;

        public NhsLoginTests(ITestOutputHelper output)
        {
            this.output = output;

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            configuration = configurationBuilder.Build();

            this.apiPlatformConfigurations = configuration
                .GetSection("CIS").Get<ApiPlatformConfigurations>();

            var apiPlatformClient = new ApiPlatformClient(this.apiPlatformConfigurations);
            this.careIdentityServiceClient = apiPlatformClient.CareIdentityServiceClient;
        }
    }
}