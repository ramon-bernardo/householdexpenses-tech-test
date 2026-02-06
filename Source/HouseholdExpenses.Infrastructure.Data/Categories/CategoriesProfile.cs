using AutoMapper;
using HouseholdExpenses.Domain.Categories.Entities;
using HouseholdExpenses.Infrastructure.Data.Categories.Models;

namespace HouseholdExpenses.Infrastructure.Data.Categories;

public sealed class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CategoryPurpose, CategoryPurposeModel>();
        CreateMap<CategoryPurposeModel, CategoryPurpose>();

        CreateMap<Category, CategoryModel>();
        CreateMap<CategoryModel, Category>()
            .ConstructUsing((model, context) =>
            {
                return Category.Create(model.Description, context.Mapper.Map<CategoryPurpose>(model.Purpose));
            });

    }
}
