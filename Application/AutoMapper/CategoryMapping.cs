using AutoMapper;
using Core.Dtos.Category;
using Core.Entities;

namespace Application.AutoMapper
{
	public class CategoryMapping:Profile
	{
		public CategoryMapping()
		{
			CreateMap<CreateCategoryDto, Category>();
			CreateMap<UpdateCategoryDto, Category>();
			CreateMap<Category, GetCategoryDto>().ReverseMap();
		}
	}
}
