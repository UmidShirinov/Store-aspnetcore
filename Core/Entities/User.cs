﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedAt { get; set; }= DateTime.Now;

		// Bir istifadəçinin sifarişləri
		public ICollection<Order> Orders { get; set; }
		public ICollection<Payment> Payments { get; set; }

		public Token Token { get; set; }

	}
}
