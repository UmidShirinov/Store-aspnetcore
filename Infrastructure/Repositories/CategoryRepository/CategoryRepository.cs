using Core.Entities;
using Core.Repositories.CategoryRepository;
using Core.Repositories.Repository;
using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CategoryRepository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext context;

		public CategoryRepository(ApplicationDbContext _context) :base(_context) 
		{
			_context = _context;
		}

		public async Task<Category> GetCategoryWithProductsAsync(int categoryId)
		{
			return await _context.Categories
				.Include(p => p.Products)
				.FirstOrDefaultAsync(c=>c.Id==categoryId);
				
				
		}
	}
}
