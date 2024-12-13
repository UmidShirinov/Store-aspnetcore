using Core.Entities;
using Core.Repositories.OrderRepository;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderRepository
{
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _contex;

		public OrderRepository(ApplicationDbContext contex) :base(contex) 
		{
			_contex = contex;
				
		}
		public async Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId)
		{
			return await _contex.Orders
				.Where(o => o.UserId == userId)
				.ToListAsync();
		}
	}
}
