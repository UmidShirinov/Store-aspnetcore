using Core.Dtos;

namespace Core.Services.AuthService
{
	public interface IAuthService
	{
		public string GenerateTokemn(string username, int userId);
		public bool ValidateToken(string token);
	}
}
