namespace Infrastructure.Services.SendEmailService
{
	public interface ISendEmailService
	{
		Task<bool> SendEmailAsync(string to,string token);
	}
}
