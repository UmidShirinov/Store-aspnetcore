
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http;

namespace Infrastructure.Services.SendEmailService
{
	public class SendEmailService : ISendEmailService
	{
		private readonly IConfiguration _configuration;
		private readonly string _email;
		private readonly string _password;
		public SendEmailService(IConfiguration configuration)
		{
			_configuration = configuration;
			_email = _configuration["EmailSettings:Email"];
			_password = _configuration["EmailSettings:Password"];
		}
		public async Task<bool> SendEmailAsync(string to, string token)
		{

			using (var smtpClient = new SmtpClient())
			{
				smtpClient.EnableSsl = true;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(_email, _password);
				smtpClient.Port = 587;
				smtpClient.Host = "smtp.gmail.com";

				MailMessage message = new MailMessage();
				message.From = new MailAddress(_email);
				message.IsBodyHtml = true;
				StringBuilder mailBody = new StringBuilder();

				//mailBody.AppendFormat("<h1>User Registered</h1>");
				//mailBody.AppendFormat("<br />");
				//mailBody.AppendFormat("<p>Thank you For Registering account</p>");


				var param = new Dictionary<string, string>()
			{
				{ "token" , token },
				{"email" , to},
			};
				message.To.Add(to);
				var url = "https://example.com/reset-password";
				var queryString = QueryHelpers.AddQueryString(url, param);
				mailBody.AppendFormat($"<p><a href='{0}'>{queryString}</a></p>");

				message.Body = mailBody.ToString();

				try
				{
					await smtpClient.SendMailAsync(message);
					return true;
				}
				catch (Exception ex)
				{
					// Hata idarəetməsi
					Console.WriteLine($"E-poçt göndərilmədi: {ex.Message}");
					return false;
				}
			}
		}
	}
}
