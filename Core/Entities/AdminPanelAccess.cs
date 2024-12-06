namespace Core.Entities
{
	public class AdminPanelAccess
	{
		public int Id { get; set; }
		public int UserId { get; set; } // Foreign Key (Admin istifadəçisi)
		public User? User { get; set; } // Navigation Property

		public bool HasAccess { get; set; } // Admin-in panelə daxil olmaq icazəsi
	}
}
