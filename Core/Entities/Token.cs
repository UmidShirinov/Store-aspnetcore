namespace Core.Entities
{
	public class Token
	{
		public int Id { get; set; } // Token üçün unikal ID
		public int UserId { get; set; } // User üçün xarici açar
		public string AccessToken { get; set; } // Access Token
		public DateTime AccessTokenExpiresAt { get; set; } // Access Token-in bitmə tarixi		
		public User User { get; set; } // İstifadəçi ilə əlaqə
	}
}
