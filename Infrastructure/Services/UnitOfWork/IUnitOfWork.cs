using Core.Repositories.BasketRepository;
using Core.Repositories.CategoryRepository;
using Core.Repositories.OrderRepository;
using Core.Repositories.ProductRepository;
using Core.Repositories.UserRepository;

namespace Core.Services.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository UserRepository { get; }
		IProductRepository ProductRepository { get; }
		ICategoryRepository Categories { get; }
		IOrderRepository Orders { get; }
		IBasketRepository Baskets { get; }
		Task<int> SaveChangesAsync();
	}
}
