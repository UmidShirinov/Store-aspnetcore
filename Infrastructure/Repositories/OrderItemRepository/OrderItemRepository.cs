using Core.Entities;
using Core.Repositories.OrderRepository;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderItemRepository
{
	public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
	{
		private readonly ApplicationDbContext _context;
		public OrderItemRepository(ApplicationDbContext context):base(context) 
		{
			_context = context;	
		}

		public async Task<IEnumerable<OrderItem>> GetItemByOrderIdAsync(int orderId)
		{
			return await _context.OrderItems.Where(p=>p.OrderId==orderId).ToListAsync();
		}
	}
}
