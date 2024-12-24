using Core.Entities;
using Core.Repositories.Repository;

namespace Infrastructure.Repositories.BasketItemRepository
{
	public interface IBasketItemRepository:IRepository<BasketItem>
	{
		Task<IEnumerable<BasketItem>> GetItemWithBasketIdAsync(int basketId);
	}
}
