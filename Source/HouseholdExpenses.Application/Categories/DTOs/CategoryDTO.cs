using HouseholdExpenses.Domain.Categories.Entities;

namespace HouseholdExpenses.Application.Categories.DTOs;

public sealed record CategoryDTO(uint Id, string Description, CategoryPurpose Purpose) { }
