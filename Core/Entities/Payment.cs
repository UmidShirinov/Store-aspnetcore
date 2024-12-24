namespace Core.Entities
{
	public class Payment
	{
		public int Id { get; set; }  // Unikal Payment ID-si
		public int OrderId { get; set; }  // Əlaqəli Order ID-si
		public DateTime PaymentDate { get; set; }  // Ödəniş tarixi
		public decimal Amount { get; set; }  // Ödəniş məbləği
		public string PaymentMethod { get; set; }  // Ödəniş metodu (məsələn: Kredit Kartı, Nağd və s.)
		public string Status { get; set; }  // Ödənişin vəziyyəti (məsələn: Uğurlu, Uğursuz)
		public int UserId { get; set; }  // Ödənişi edən istifadəçi ID-si

		// Əlaqəli Order (One-to-Many relation)
		public Order Order { get; set; }

		// Əlaqəli User (One-to-Many relation)
		public User User { get; set; }
	}
}
