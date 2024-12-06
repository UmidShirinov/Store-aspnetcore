namespace Core.Entities
{
	public class Basket
	{
		public int Id { get; set; }
		public int UserId { get; set; } // Foreign Key (Hansı istifadəçiyə aid olduğu)
		public User User { get; set; } // Navigation Property

		public ICollection<BasketItem> BasketItems { get; set; } // Səbətə əlavə edilən məhsullar
	}
}
