using Core.Dtos.BasketDtos;

namespace Core.Services.BasketService
{
	public interface IBasketService
	{
		Task AddToBasketAsync(int userId, int productId, int quantity);
		Task RemoveFromBasketAsync(int userId, int productId);
		Task<GetBasketDto> GetBasketAsync(int userId);
	}
}
