using Core.Entities;
using Core.Repositories.Repository;

namespace Infrastructure.Repositories.BasketItemRepository
{
	public interface IBasketRepository:IRepository<Basket>
	{
		Task<Basket> GetBasketWithItemByBasketIdAsync(int basketId);
	}
}
