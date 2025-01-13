using Core.Entities;
using Core.Repositories.CategoryRepository;
using Core.Repositories.OrderRepository;
using Core.Repositories.ProductRepository;
using Core.Repositories.Repository;
using Core.Repositories.UserRepository;
using Core.Services.UnitOfWork;
using Infrastructure.Contex;
using Infrastructure.Repositories.BasketItemRepository;
using Infrastructure.Repositories.BasketRepository;
using Infrastructure.Repositories.CategoryRepository;
using Infrastructure.Repositories.OrderItemRepository;
using Infrastructure.Repositories.OrderRepository;
using Infrastructure.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public IUserRepository Users { get; set; }
		public IRepository<Product> Products { get; set; }
		public IRepository<Category> Categories { get; set; }
		public IRepository<Order> Orders { get; set; }
		public IRepository<OrderItem> OrderItems { get; set; }
		public IRepository<Basket> Baskets { get; set; }
		public IRepository<BasketItem> BasketItems { get; set; }
		public IRepository<Token> Tokens { get; set; }



		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Users = new UserRepository(_context);
			Products = new Repository<Product>(_context);
			Categories = new Repository<Category>(_context);
			Orders = new Repository<Order>(_context);
			OrderItems = new Repository<OrderItem>(_context);
			Baskets = new Repository<Basket>(_context);
			BasketItems = new Repository<BasketItem>(_context);
			Tokens = new Repository<Token>(_context);
		}

		//public IRepository<User> Users { get; private set; }
		//public IRepository<Product> Products { get; private set; }
		//public IRepository<Category> Categories { get; private set; }
		//public IRepository<Order> Orders { get; private set; }
		//public IRepository<OrderItem> OrderItems { get; private set; }
		//public IRepository<Basket> Baskets { get; private set; }
		//public IRepository<BasketItem> BasketItems { get; private set; }

		//public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

		//public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

		//public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

		//public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

		//public IOrderItemRepository orderItems => _orderItemRepository ??= new OrderItemRepository(_context);

		//public IBasketRepository Baskets => _basketRepository ??= new BasketRepository(_context);

		//public IBasketItemRepository basketItems => _basketItemRepository ??= new BasketItemRepository(_context);

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
