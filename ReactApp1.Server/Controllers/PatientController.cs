using Microsoft.AspNetCore.Mvc;
using NHS.Digital.ApiPlatform.Sdk.Clients.ApiPlatforms;

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
            string body = await this.apiPlatformClient
                .PersonalDemographicsServiceClient
                .SearchPatientsAsync(
                    family: "Smith",
                    given: null,
                    gender: "female",
                    birthdate: new DateOnly(2010, 10, 22),
                    cancellationToken: cancellationToken);

            return Content(body, "application/fhir+json");
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Error while searching for patients.");

            // If token is missing/expired you will typically see an unauthorized exception
            // bubble up from the SDK. Return 401 as the most useful default.
            return Unauthorized();
        }
    }
}
