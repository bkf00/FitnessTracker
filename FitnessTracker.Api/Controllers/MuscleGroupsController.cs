using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/muscle-groups")]
public sealed class MuscleGroupsController : ControllerBase
{
    private readonly IMuscleGroupService _service;

    public MuscleGroupsController(IMuscleGroupService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}
