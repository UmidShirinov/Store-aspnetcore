namespace Core.Dtos.PaymentDtos
{
	public class CreatePaymentDto
	{
		public decimal Amount { get; set; } // Ödəniş məbləği
		public int UserId { get; set; } // Ödənişi edən istifadəçinin ID-si
		public string PaymentMethod { get; set; } // Ödəniş metodu (kart, nağd, və s.)
		public DateTime PaymentDate { get; set; } // Ödəniş tarixi
	}
}
