using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Domain.Categories.Entities;

namespace HouseholdExpenses.Application.Categories;

public sealed class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Category, CategoryDTO>();
    }
}
