using Core.Entities;
using Core.Repositories.Repository;

namespace Core.Repositories.OrderRepository
{
	public interface IOrderRepository : IRepository<Order>
	{
		Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId);
	}
}
