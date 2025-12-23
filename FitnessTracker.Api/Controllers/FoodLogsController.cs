using FitnessTracker.Core.Dtos.FoodLog;
using FitnessTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/food-logs")]
public sealed class FoodLogsController : ControllerBase
{
    private readonly IFoodLogService _service;

    public FoodLogsController(IFoodLogService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var log = await _service.GetByIdAsync(id);
        return log is null ? NotFound() : Ok(log);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFoodLogRequest request)
    {
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateFoodLogRequest request)
    {
        var updated = await _service.UpdateAsync(id, request);
        return updated is null ? NotFound() : Ok(updated);
    }
}
