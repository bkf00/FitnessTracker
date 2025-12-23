using FitnessTracker.Core.Repositories;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainGoal = FitnessTracker.Domain.Entities.Goal;
using EfGoal = FitnessTracker.Infrastructure.Models.Goal;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class GoalRepository : IGoalRepository
{
    private readonly FitnessDbContext _context;

    public GoalRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainGoal?> GetByIdAsync(int id)
    {
        EfGoal? entity = await _context.Goals
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(DomainGoal goal)
    {
        EfGoal entity = MapToEntity(goal);
        _context.Goals.Add(entity);
        await _context.SaveChangesAsync();

        goal.SetId(entity.Id);
    }

    public async Task<bool> UpdateAsync(DomainGoal goal)
    {
        EfGoal? entity = await _context.Goals.FindAsync(goal.Id);
        if (entity is null) return false;

        entity.TargetValue = goal.TargetValue;
        entity.EndDate = goal.EndDate;
        entity.IsAchieved = goal.IsAchieved;

        await _context.SaveChangesAsync();
        return true;
    }

    private static DomainGoal MapToDomain(EfGoal entity)
    {
        var goal = new DomainGoal(
            entity.UserId,
            entity.GoalType,
            entity.TargetValue,
            entity.StartDate,
            entity.EndDate
        );

        goal.SetId(entity.Id);
        if (entity.IsAchieved)
            goal.MarkAchieved();

        return goal;
    }

    private static EfGoal MapToEntity(DomainGoal domain)
        => new()
        {
            UserId = domain.UserId,
            GoalType = domain.GoalType,
            TargetValue = domain.TargetValue,
            StartDate = domain.StartDate,
            EndDate = domain.EndDate,
            IsAchieved = domain.IsAchieved
        };
    public async Task<bool> HasOverlappingGoalAsync(
    int userId,
    string goalType,
    DateOnly startDate,
    DateOnly endDate,
    int? excludeGoalId = null)
    {
        return await _context.Goals
            .AsNoTracking()
            .AnyAsync(g =>
                g.UserId == userId &&
                g.GoalType == goalType &&
                (!excludeGoalId.HasValue || g.Id != excludeGoalId.Value) &&
                g.StartDate <= endDate &&
                g.EndDate >= startDate);
    }
}
