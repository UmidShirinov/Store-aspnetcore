using AutoMapper;
using Azure.Core;
using Core.Dtos.UserDtos;
using Core.Entities;
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
		private readonly IMapper _mapper;
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

			var accessToken = _authService.GenerateToken(user.Name, user.Id);

			var entity = new Token
			{
				UserId = user.Id,
				AccessToken = accessToken,
				AccessTokenExpiresAt = DateTime.Now.AddHours(2)
			};

			await _unitOfWork.Tokens.AddAsync(entity);
			await _unitOfWork.SaveChangesAsync();

			

			return new LoginUserDto { Token = accessToken, UserId = user.Id, UserName = user.Name };
			

		}
	}
}
