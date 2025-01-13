using Core.Entities;
using Core.Repositories.Repository;
using Infrastructure.Contex;

namespace Infrastructure.Repositories.TokenRepository
{
	public class TokenRepository : Repository<Token>, ITokenRepository
	{
		public TokenRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
