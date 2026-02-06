using MediatR;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Domain.Categories.Entities;

namespace HouseholdExpenses.Application.Categories.Commands;

public sealed record CreateCategoryCommand(
    string Description,
    CategoryPurpose Purpose
) : IRequest<CategoryDTO>
{ }
