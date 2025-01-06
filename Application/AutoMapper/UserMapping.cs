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
			CreateMap<GetUserByIdDto, User>().ReverseMap();
			CreateMap<GetUserDto, User>().ReverseMap();
			CreateMap<UpdateUserDto, User>();
		}
	}
}
