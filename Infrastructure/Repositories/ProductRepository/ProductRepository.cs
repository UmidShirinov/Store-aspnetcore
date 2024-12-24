using Core.Entities;
using Core.Repositories.ProductRepository;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository
{
	public class ProductRepository:Repository<Product> , IProductRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;	
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
		{
			return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
		}
	}
}
