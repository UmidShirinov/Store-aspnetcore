using AutoMapper;
using Core.Dtos.Category;
using Core.Services.UnitOfWork;
using MediatR;

namespace Application.App.Queries.CategoryQuery.GetCategories
{
	public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			
		}
		public async Task<List< GetCategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Categories.GetAllAsync();

			return _mapper.Map<List<GetCategoryDto>>(result);
		}
	}
}
