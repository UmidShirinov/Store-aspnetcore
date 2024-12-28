using AutoMapper;
using Core.Dtos.UserDtos;
using Core.Entities;

namespace Application.AutoMapper
{
	public class UserMapping:Profile
	{
		public UserMapping()
		{
			CreateMap<CreateUserDto, User>();
			CreateMap<GetUserByIdDto, User>();
			CreateMap<GetUserDto, User>();
			CreateMap<UpdateUserDto, User>();
		}
	}
}
