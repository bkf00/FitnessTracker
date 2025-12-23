using FitnessTracker.Core.Dtos.MeasurementLog;
using FitnessTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/measurement-logs")]
public sealed class MeasurementLogsController : ControllerBase
{
    private readonly IMeasurementLogService _service;

    public MeasurementLogsController(IMeasurementLogService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMeasurementLogRequest request)
    {
        var created = await _service.CreateAsync(request);
        return Ok(created);
    }
}
