using MediatR;
using HouseholdExpenses.Application.Categories.DTOs;

namespace HouseholdExpenses.Application.Categories.Queries;

public sealed record GetAllCategoryQuery : IRequest<IEnumerable<CategoryDTO>> { }
