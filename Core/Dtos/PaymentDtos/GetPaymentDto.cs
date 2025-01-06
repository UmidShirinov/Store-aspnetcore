namespace Core.Dtos.PaymentDtos
{
	public class GetPaymentDto
	{
		public int Id { get; set; }  // Ödənişin unikal ID-si
		public int OrderId { get; set; }  // Əlaqəli sifarişin ID-si
		public DateTime PaymentDate { get; set; }  // Ödəniş tarixi
		public decimal Amount { get; set; }  // Ödəniş məbləği
		public string PaymentMethod { get; set; }  // Ödəniş metodu (Kredit Kartı, Nağd və s.)
		public string Status { get; set; }  // Ödənişin vəziyyəti (Uğurlu, Uğursuz)
		public int UserId { get; set; }  // Ödənişi edən istifadəçinin ID-si
		public string UserName { get; set; }  // İstifadəçinin adı (əgər əlavə məlumat lazımdırsa)
		public string OrderDescription { get; set; }  // Sifariş haqqında qısa məlumat (opsional)
	}
}

