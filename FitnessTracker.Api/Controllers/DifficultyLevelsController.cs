using FitnessTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/difficulty-levels")]
public sealed class DifficultyLevelsController : ControllerBase
{
    private readonly IDifficultyLevelService _service;

    public DifficultyLevelsController(IDifficultyLevelService service)
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
