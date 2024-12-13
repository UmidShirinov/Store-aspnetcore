using Core.Dtos;

namespace Core.Services.AuthService
{
	public interface IAuthService
	{
		Task<string> AuthenticateAsync(string email, string password);
		Task RegisterAsync(UserDto userDto);
	}
}
