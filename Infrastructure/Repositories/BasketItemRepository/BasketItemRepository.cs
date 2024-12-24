using Core.Entities;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BasketItemRepository
{
	public class BasketItemRepository:Repository<BasketItem> , IBasketItemRepository
	{
		private readonly ApplicationDbContext _context;

		public BasketItemRepository(ApplicationDbContext context) : base(context) 
		{
			_context = context;		
		}

		public async Task<IEnumerable<BasketItem>> GetItemWithBasketIdAsync(int basketId)
		{
			return await _context.BasketItems
				.Where(p => p.BasketId ==basketId)
				.ToListAsync();
		}

		
	}
}
