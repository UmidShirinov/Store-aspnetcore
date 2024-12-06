namespace Core.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int UserId { get; set; } // Foreign Key (Sifarişi verən istifadəçi)
		public User User { get; set; } // Navigation Property
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }

		// Bir sifarişdə bir neçə məhsul ola bilər
		public ICollection<OrderItem> OrderItems { get; set; }
	}
}
