using Core.Services.UnitOfWork;
using Infrastructure.Services.PasswordHashService;
using MediatR;

namespace Application.App.Commands.UserCommands.ResetPassword
{

	public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPasswordService _passwordService;
		public ResetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordService passwordService)
		{
			_passwordService = passwordService;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
			if (user == null)
			{
				throw new Exception("Istifadeci tapilmadi");
			}

			var isVerifyOldPassword= _passwordService.VerifyPassword(request.OldPassword, user.PasswordHash);
			if (!isVerifyOldPassword)
			{
				throw new Exception("Kohne sifre duz deil");
			}

			if (request.NewPassword != request.ConfirmNewPassword)
			{
				throw new Exception("Yeni şifrə ilə təsdiq şifrəsi eyni deyil.");
			}

			user.PasswordHash = _passwordService.Hash(request.NewPassword);
			_unitOfWork.Users.Update(user);
			_unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
