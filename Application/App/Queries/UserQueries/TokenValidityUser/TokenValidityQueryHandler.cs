using Core.Services.AuthService;
using MediatR;

namespace Application.App.Queries.UserQueries.TokenValidityUser
{
	public class TokenValidityQueryHandler : IRequestHandler<TokenValidityQuery, bool>
	{
		private readonly IAuthService _authService;

		public TokenValidityQueryHandler(IAuthService authService)
		{
			_authService=authService;
		}
		public async Task<bool> Handle(TokenValidityQuery request, CancellationToken cancellationToken)
		{
			var isValid =  _authService.ValidateToken(request.Token);

			return isValid;
		}
	}
}
