using FitnessTracker.Core.Dtos.Exercise;
using FitnessTracker.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/exercises")]
public sealed class ExercisesController : ControllerBase
{
    private readonly IExerciseService _service;

    public ExercisesController(IExerciseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var exercises = await _service.GetAllAsync();
        return Ok(exercises);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exercise = await _service.GetByIdAsync(id);
        return exercise is null ? NotFound() : Ok(exercise);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExerciseRequest request)
    {
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}
