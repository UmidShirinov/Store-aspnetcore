namespace Infrastructure.Services.TokenService
{
	public interface ITokenService
	{
		string GeneratePasswordResetToken(int userId);
	}
}
