namespace Core.Entities
{
	public class BasketItem
	{
		public int Id { get; set; }
		public int BasketId { get; set; } // Foreign Key (Hansı səbətə aid olduğu)
		public Basket Basket { get; set; } // Navigation Property

		public int ProductId { get; set; } // Foreign Key (Məhsul)
		public Product Product { get; set; } // Navigation Property

		public int Quantity { get; set; } // Məhsulun miqdarı
	}
}
