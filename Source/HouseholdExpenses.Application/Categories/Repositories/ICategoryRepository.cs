using HouseholdExpenses.Domain.Categories.Entities;

namespace HouseholdExpenses.Application.Categories.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetById(uint id);

    Task<IReadOnlyCollection<Category>> GetAll();

    Task<Category> Add(Category category);
}
