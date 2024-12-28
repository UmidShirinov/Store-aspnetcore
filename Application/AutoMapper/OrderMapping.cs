using AutoMapper;
using Core.Dtos.OrderDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class OrderMapping:Profile
	{
		public OrderMapping()
		{
			CreateMap<CreateOrderDto, Order>();
			CreateMap<UpdateOrderDto, Order>();
			CreateMap<GetOrderDto, Order>();
			CreateMap<GetOrdersByUserDto, Order>();
		}
	}
}
