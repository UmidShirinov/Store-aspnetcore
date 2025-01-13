using Core.Services.UnitOfWork;
using MediatR;

namespace Application.App.Commands.UserCommands.LogOutUser
{
	public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommand,bool>
	{
		private readonly IUnitOfWork _unitOfWork;

		public LogOutUserCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;	
		}

		public async Task<bool> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
		{
			var token = await _unitOfWork.Tokens.GetByIdAsync(request.UserId);
			if (token == null)
			{
				return false;
			}

			_unitOfWork.Tokens.Delete(token);
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
