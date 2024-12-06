namespace Core.Entities
{
	public class Profile
	{
		public int Id { get; set; }
		public int UserId { get; set; } // Foreign Key (Hansı istifadəçiyə aid olduğu)
		public User User { get; set; } // Navigation Property

		public string Address { get; set; } // İstifadəçinin ünvanı
		public string PhoneNumber { get; set; } // İstifadəçinin telefon nömrəsi
	}
}
