using AutoMapper;
using Core.Dtos.AuthDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class AuthMapping:Profile
	{
		public AuthMapping()
		{
			
			CreateMap<RegisterDto, User>();
		

		}
	}
}
