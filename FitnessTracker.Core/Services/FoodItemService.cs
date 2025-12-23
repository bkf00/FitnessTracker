using FitnessTracker.Core.Dtos.FoodItem;
using FitnessTracker.Core.Exceptions;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _repository;

    public FoodItemService(IFoodItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<FoodItemDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(FoodItemMapper.ToDto).ToList();
    }

    public async Task<FoodItemDto?> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return item is null ? null : FoodItemMapper.ToDto(item);
    }

    public async Task<FoodItemDto> CreateAsync(CreateFoodItemRequest request)
    {
        if (await _repository.ExistsByNameAsync(request.Name))
            throw new BusinessRuleException("Food item with the same name already exists.");

        var foodItem = new FoodItem(
            request.Name,
            request.Calories,
            request.Protein,
            request.Carbs,
            request.Fat);

        await _repository.AddAsync(foodItem);
        return FoodItemMapper.ToDto(foodItem);
    }
}
