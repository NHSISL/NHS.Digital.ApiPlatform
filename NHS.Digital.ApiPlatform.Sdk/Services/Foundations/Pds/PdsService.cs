// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NHS.Digital.ApiPlatform.Sdk.Brokers.Https;
using NHS.Digital.ApiPlatform.Sdk.Brokers.Identifiers;
using NHS.Digital.ApiPlatform.Sdk.Models.Configurations;
using NHS.Digital.ApiPlatform.Sdk.Models.Foundations.Patients;

namespace NHS.Digital.ApiPlatform.Sdk.Services.Foundations.Pds
{
    internal partial class PdsService : IPdsService
    {
        private readonly ApiPlatformConfigurations configurations;
        private readonly IHttpBroker httpBroker;
        private readonly IIdentifierBroker identifierBroker;

        public PdsService(
            ApiPlatformConfigurations configurations,
            IHttpBroker httpBroker,
            IIdentifierBroker identifierBroker)
        {
            this.configurations = configurations;
            this.httpBroker = httpBroker;
            this.identifierBroker = identifierBroker;
        }

        public ValueTask<string> SearchPatientsAsync(
			string accessToken,
			Patient patient,
			CancellationToken cancellationToken = default) =>
        TryCatch(async () =>
        {
            string baseUrl = this.configurations.PersonalDemographicsService.BaseUrl.TrimEnd('/');
            string url;

            if (!string.IsNullOrWhiteSpace(patient.NhsNumber))
            {
                url = $"{baseUrl}/Patient/{patient.NhsNumber}";
            }
            else
            {
                url = $"{baseUrl}/Patient?family={Uri.EscapeDataString(patient.Surname)}";

                if (patient.GivenName is not null)
            {
                foreach (string givenName in patient.GivenName.Where(n => !string.IsNullOrWhiteSpace(n)))
                {
                    url += $"&given={Uri.EscapeDataString(givenName)}";
                }
            }

            if (!string.IsNullOrWhiteSpace(patient.Gender))
            {
                url += $"&gender={Uri.EscapeDataString(patient.Gender)}";
            }

                if (patient.DateOfBirth != default)
                {
                    url += $"&birthdate=eq{patient.DateOfBirth:yyyy-MM-dd}";
                }
            }

            var response = await this.httpBroker.GetAsync(
                url,
                request =>
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    request.Headers.Add("X-Request-ID", this.identifierBroker.GetNewGuid().ToString());
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/fhir+json"));
                },
                cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(cancellationToken);
        });
    }
}
