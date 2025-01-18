using MediatR;

namespace Application.App.Queries.UserQueries.TokenValidityUser
{
	public class TokenValidityQuery:IRequest<bool>
	{
		public string Token { get; set; }
	}
}
