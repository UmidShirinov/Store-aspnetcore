using Core.Entities;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.UserRepository
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<User> GetByEmailAsync(string email)
		{
			return await  _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<bool> IsEmailTaken(string email)
		{
			return await _context.Users.AnyAsync(x => x.Email == email);
		}
	}
}
