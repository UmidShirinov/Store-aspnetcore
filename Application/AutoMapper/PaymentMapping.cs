using AutoMapper;
using Core.Dtos.PaymentDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class PaymentMapping:Profile
	{
		public PaymentMapping()
		{
			CreateMap<Payment, GetPaymentDto>()
				.ForMember(o => o.UserName, x => x.MapFrom(u => u.User.Name));
			CreateMap<CreatePaymentDto, Payment>();
		}
	}
}
