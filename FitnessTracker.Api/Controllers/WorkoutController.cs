using FitnessTracker.Core.Dtos.Workout;
using FitnessTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/workouts")]
public sealed class WorkoutsController : ControllerBase
{
    private readonly IWorkoutService _service;

    public WorkoutsController(IWorkoutService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workout = await _service.GetByIdAsync(id);
        return workout is null ? NotFound() : Ok(workout);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkoutRequest request)
    {
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateWorkoutRequest request)
    {
        var updated = await _service.UpdateAsync(id, request);
        return updated is null ? NotFound() : Ok(updated);
    }
}
