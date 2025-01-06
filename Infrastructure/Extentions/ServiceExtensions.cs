

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Extentions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
				ValidateIssuer = true,
				ValidIssuer = configuration["Jwt:Issuer"],
				ValidateAudience = true,
				ValidAudience = configuration["Jwt:Audience"],
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};


			options.Events = new JwtBearerEvents
			{
				OnAuthenticationFailed = context =>
				{
					// Token doğrulama səhv olduqda, Unauthorized qaytarın
					context.Response.StatusCode = 401;
					return Task.CompletedTask;
				}
			};
		});

			return services;
		}
	}
}
