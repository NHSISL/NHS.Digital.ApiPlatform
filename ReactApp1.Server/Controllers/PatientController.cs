using Microsoft.AspNetCore.Mvc;
using NHS.Digital.ApiPlatform.Sdk.Clients.ApiPlatforms;
using NHS.Digital.ApiPlatform.Sdk.Models.Foundations.Patients;

namespace ReactApp1.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IApiPlatformClient apiPlatformClient;
    private readonly ILogger<PatientController> logger;

    public PatientController(
        IApiPlatformClient apiPlatformClient,
        ILogger<PatientController> logger)
    {
        this.apiPlatformClient = apiPlatformClient;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatient(CancellationToken cancellationToken)
    {
        try
        {
            var patient = new Patient
            {
                NhsNumber = "9000000009",
                Surname = "Smith",
                GivenName = null,
                Gender = "female",
                DateOfBirth = new DateTimeOffset(new DateOnly(2010, 10, 22), TimeOnly.MinValue, TimeSpan.Zero)
            };

			string body = await this.apiPlatformClient
				.PersonalDemographicsServiceClient
				.SearchPatientsAsync(
					patient,
					cancellationToken: cancellationToken);

			return Content(body, "application/fhir+json");
		}
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Error while searching for patients.");

            return Unauthorized();
        }
    }
}
