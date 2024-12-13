using Core.Entities;
using Core.Repositories.Repository;

namespace Core.Repositories.ProductRepository
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
	}
}
