using Core.Entities;
using Core.Repositories.Repository;

namespace Core.Repositories.BasketRepository
{
	public interface IBasketRepository : IRepository<Basket>
	{
		Task<Basket> GetBasketByUserIdAsync(int userId);
	}
}
