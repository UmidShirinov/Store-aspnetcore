using Core.Dtos.UserDtos;
using MediatR;

namespace Application.App.Commands.UserCommands.ResetPassword
{
	public class ResetPasswordCommand:ResetPasswordDto, IRequest<bool>
	{
		public int UserId { get; set; }
	}
}
