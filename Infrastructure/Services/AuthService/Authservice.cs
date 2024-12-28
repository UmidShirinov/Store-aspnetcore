using Core.Services.AuthService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.AuthService
{
	public class Authservice : IAuthService
	{
		private readonly IConfiguration _configuration;
		private readonly string securityKey;
		private readonly string issuer;
		private readonly string audience;


		public Authservice(IConfiguration configuration)
		{
			_configuration = configuration;
			securityKey = _configuration["Jwt:SecretKey"];
			issuer = configuration["Jwt:Issuer"];
			audience = configuration["Jwt:Audience"];
		}
		public string GenerateTokemn(string username, int userId)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
				new Claim(ClaimTypes.Name, username),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

			var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims: claims,
				expires: DateTime.Now.AddHours(2),
				signingCredentials: credential
				);

			return new JwtSecurityTokenHandler().WriteToken(token);

		}

		public bool ValidateToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(token);

			try
			{
				var validationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true, // İstəyə bağlı yoxlama
					ValidateAudience = true, // İstəyə bağlı yoxlama
					ValidateLifetime = true, // Token müddətini yoxlayır
					ClockSkew = TimeSpan.Zero // Saat fərqi üçün tənzimləmə
				};

				tokenHandler.ValidateTokenAsync(token, validationParameters);
				return true;
			}
			catch (Exception )
			{

				
				return false;
			}
		}
	}
}
