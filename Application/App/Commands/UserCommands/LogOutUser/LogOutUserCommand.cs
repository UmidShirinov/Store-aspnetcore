using MediatR;

namespace Application.App.Commands.UserCommands.LogOutUser
{
	public class LogOutUserCommand: IRequest<bool>
	{
		public int UserId { get; set; }
	}
}
