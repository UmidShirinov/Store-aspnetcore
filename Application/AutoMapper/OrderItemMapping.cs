using AutoMapper;
using Core.Dtos.OrderitemDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class OrderItemMapping:Profile
	{
		public OrderItemMapping()
		{
			CreateMap<CreateOrderItemDto, OrderItem>();
			CreateMap<UpdateOrderItemDto, OrderItem>();
			CreateMap<GetOrderItemDto, OrderItem>();
		}
	}
}
