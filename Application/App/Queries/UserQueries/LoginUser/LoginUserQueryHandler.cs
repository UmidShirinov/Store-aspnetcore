using Core.Dtos.UserDtos;
using Core.Services.AuthService;
using Core.Services.UnitOfWork;
using Infrastructure.Services.PasswordHashService;
using MediatR;

namespace Application.App.Queries.UserQueries.LoginUser
{
	public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPasswordService _passwordService;
		private readonly IAuthService _authService;
		public LoginUserQueryHandler(IUnitOfWork unitOfWork, IPasswordService passwordService, IAuthService authService)
		{
			_unitOfWork = unitOfWork;
			_passwordService = passwordService;
			_authService = authService;
		}
		public async Task<LoginUserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
			var isVerify = _passwordService.VerifyPassword(request.Password, user.PasswordHash);
			if (user == null || !isVerify)
			{
				throw new UnauthorizedAccessException("Email or Password is Wrong");
			}

			var token = _authService.GenerateToken(user.Name, user.Id);

			return new LoginUserDto { Token = token, UserId = user.Id, UserName = user.Name };
		}
	}
}
