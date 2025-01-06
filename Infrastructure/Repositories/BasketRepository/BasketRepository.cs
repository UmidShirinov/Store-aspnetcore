using Core.Entities;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Infrastructure.Repositories.BasketItemRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BasketRepository
{
	public class BasketRepository : Repository<Basket>, IBasketRepository
	{
		private readonly ApplicationDbContext _context;
		public BasketRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Basket> GetBasketWithItemByBasketIdAsync(int basketId)
		{
			return await _context.Baskets
				.Include(p => p.BasketItems)
				.FirstOrDefaultAsync(p => p.Id == basketId);
		}


	}
}
