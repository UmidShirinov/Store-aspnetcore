using Core.Dtos.Category;
using MediatR;

namespace Application.App.Queries.CategoryQuery.GetCategories
{
	public class GetCategoryQuery:IRequest<List<GetCategoryDto>>
	{
	}
}
