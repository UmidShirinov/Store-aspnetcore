namespace Core.Entities
{
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; } // Məsələn: Admin, Customer, Seller
		public string Description { get; set; } // Rolun təsviri
		public ICollection<User> Users { get; set; } // Bir rol bir neçə istifadəçiyə aid ola bilər
	}
}
