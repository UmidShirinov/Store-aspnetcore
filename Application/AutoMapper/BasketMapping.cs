using AutoMapper;
using Core.Dtos.BasketDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class BasketMapping:Profile
	{
		public BasketMapping()
		{
			CreateMap<AddToBasketDto, Basket>();
			CreateMap<RemoveFromBasketDto, Basket>();
			CreateMap<GetBasketDto, Basket>();
		}
	}
}
