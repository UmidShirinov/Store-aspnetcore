using AutoMapper;
using Core.Dtos.ProductDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class ProductMapping:Profile
	{
		public ProductMapping()
		{
			CreateMap<CreateProductDto, Product>();
			CreateMap<UpdateProductDto, Product>();
			CreateMap<GetProductsByCategoryDto, Product>();
			CreateMap<GetProductDto, Product>();
		}
	}
}
