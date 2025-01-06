using Core.Entities;
using Core.Repositories.CategoryRepository;
using Core.Repositories.OrderRepository;
using Core.Repositories.ProductRepository;
using Core.Repositories.Repository;
using Core.Repositories.UserRepository;
using Infrastructure.Repositories.BasketItemRepository;
using Infrastructure.Repositories.OrderItemRepository;

namespace Core.Services.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }
		IRepository<Product> Products { get; }
		IRepository<Category> Categories { get; }
		IRepository<Order> Orders { get; }
		IRepository<OrderItem> OrderItems { get; }
		IRepository<Basket> Baskets { get; }
		IRepository<BasketItem> BasketItems  { get; }
		Task<int> SaveChangesAsync();
	}
}
