namespace Core.Entities
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int OrderId { get; set; } // Foreign Key (Hansı sifarişə aid olduğu)
		public Order Order { get; set; } // Navigation Property

		public int ProductId { get; set; } // Foreign Key (Məhsul)
		public Product Product { get; set; } // Navigation Property

		public int Quantity { get; set; } // Məhsulun miqdarı
		public decimal Price { get; set; } // Məhsulun qiyməti
	}
}
