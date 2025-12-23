using System.Net;
using FitnessTracker.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FitnessTracker.Api.Middlewares;

public sealed class ProblemDetailsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ProblemDetailsMiddleware> _logger;

    public ProblemDetailsMiddleware(
        RequestDelegate next,
        ILogger<ProblemDetailsMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            var problem = MapToProblemDetails(ex, context);
            context.Response.StatusCode = problem.Status ?? 500;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(problem);
        }
    }

    private static ProblemDetails MapToProblemDetails(
        Exception exception,
        HttpContext context)
    {
        return exception switch
        {
            BusinessRuleException bre => new ProblemDetails
            {
                Title = "Business rule violation",
                Detail = bre.Message,
                Status = StatusCodes.Status400BadRequest,
                Instance = context.Request.Path
            },

            SqlException sql when sql.Number is 51001 or 51005 or 51006 or 51007
                => new ProblemDetails
                {
                    Title = "Business constraint violation",
                    Detail = sql.Message,
                    Status = StatusCodes.Status409Conflict,
                    Instance = context.Request.Path
                },

            SqlException sql when sql.Number == 547
                => new ProblemDetails
                {
                    Title = "Invalid reference",
                    Detail = "Referenced entity does not exist.",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.Request.Path
                },

            _ => new ProblemDetails
            {
                Title = "Internal server error",
                Detail = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError,
                Instance = context.Request.Path
            }
        };
    }
}
