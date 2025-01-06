using Core.Dtos.UserDtos;
using MediatR;

namespace Application.App.Commands.UserCommands.RegisterUser
{
	public class RegisterUserCommand:CreateUserDto ,IRequest<bool>
	{
	}
}
