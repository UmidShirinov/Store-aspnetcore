using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services.PasswordHashService
{
	public class PasswordService : IPasswordService
	{
		public string Hash(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				// UTF-8 formatında parolu byte massivinə çeviririk
				byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

				// Hash nəticəsini əldə edirik
				byte[] hashBytes = sha256.ComputeHash(passwordBytes);

				// Hash edilmiş byte massivini hex string formatına çeviririk
				StringBuilder hashedPassword = new StringBuilder();
				foreach (byte b in hashBytes)
				{
					hashedPassword.Append(b.ToString("x2")); // Hex formatında
				}

				return hashedPassword.ToString();
			}
		}

		public bool VerifyPassword(string password, string hashingPassword)
		{
			var newHashingPassword=Hash(password);
			return newHashingPassword == hashingPassword;
		}
	}
}
