using AutoMapper;
using Core.Dtos.BasketDtos;
using Core.Dtos.BasketItemDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class BasketItemMapping:Profile
	{
		public BasketItemMapping()
		{
			CreateMap<AddToBasketDto, BasketItem>();
			CreateMap<GetBasketItemsDto, BasketItem>();
			CreateMap<UpdateBasketItemDto, BasketItem>();
		}
	}
}
