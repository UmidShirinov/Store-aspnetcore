using Core.Dtos;

namespace Core.Services.BasketService
{
	public interface IBasketService
	{
		Task AddToBasketAsync(int userId, int productId, int quantity);
		Task RemoveFromBasketAsync(int userId, int productId);
		Task<BasketDto> GetBasketAsync(int userId);
	}
}
