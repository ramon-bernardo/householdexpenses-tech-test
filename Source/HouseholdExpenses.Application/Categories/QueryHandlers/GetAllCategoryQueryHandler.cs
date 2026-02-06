using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Categories.Queries;
using HouseholdExpenses.Application.Categories.Repositories;

namespace HouseholdExpenses.Application.Categories.QueryHandlers;

public sealed class GetAllCategoryQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDTO>>
{
    private readonly ICategoryRepository CategoryRepository = categoryRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await CategoryRepository.GetAll();
        var mappedCategorys = Mapper.Map<IEnumerable<CategoryDTO>>(categories);
        return mappedCategorys;
    }
}
