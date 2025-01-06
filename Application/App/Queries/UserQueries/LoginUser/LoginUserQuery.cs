using Core.Dtos.UserDtos;
using MediatR;

namespace Application.App.Queries.UserQueries.LoginUser
{
	public class LoginUserQuery:IRequest<LoginUserDto>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
