using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string Role { get; set; }
		public DateTime CreatedAt { get; set; }

		// Bir istifadəçinin sifarişləri
		public ICollection<Order> Orders { get; set; }

		// Bir istifadəçinin profili
		public Profile Profile { get; set; }

	}
}
