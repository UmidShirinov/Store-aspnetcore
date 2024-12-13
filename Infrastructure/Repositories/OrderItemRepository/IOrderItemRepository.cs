using Core.Entities;
using Core.Repositories.Repository;

namespace Infrastructure.Repositories.OrderItemRepository
{
	public interface IOrderItemRepository :IRepository<OrderItem>
	{
		Task<IEnumerable<OrderItem>> GetItemByOrderIdAsync(int orderId);
	}
}
