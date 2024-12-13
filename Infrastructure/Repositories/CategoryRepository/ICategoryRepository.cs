using Core.Entities;
using Core.Repositories.Repository;

namespace Core.Repositories.CategoryRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		Task<Category> GetCategoryWithProductsAsync(int categoryId);
	}
}
