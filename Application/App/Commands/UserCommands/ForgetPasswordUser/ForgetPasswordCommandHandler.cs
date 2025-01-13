using Core.Services.AuthService;
using Core.Services.UnitOfWork;
using Infrastructure.Services.SendEmailService;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Application.App.Commands.UserCommands.ForgetPassword
{
	public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, string>
	{
		private readonly IAuthService _authService;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ISendEmailService _emailSender;

		public ForgetPasswordCommandHandler(IAuthService authService, IUnitOfWork unitOfWork, ISendEmailService emailSender)
		{
			_authService = authService;
			_unitOfWork = unitOfWork;
			_emailSender = emailSender;
		}
		public async Task<string> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
			if (user is null) {
				return  "Bele isdifadeci yoxdur";
			}
			

			var token = _authService.GenerateToken(request.Email, user.Id);
			 var isSend = await _emailSender.SendEmailAsync(request.Email, token);
			if (isSend) { return "Email gonderildi"; }
			else
			{
				throw new Exception("Email gonderile bilmedi");
			}



		}
	}
}
