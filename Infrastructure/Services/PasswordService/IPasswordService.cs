namespace Infrastructure.Services.PasswordHashService
{
	public interface IPasswordService
	{
		string Hash(string password);
		bool VerifyPassword( string password,string hashingPassword);
	}
}
