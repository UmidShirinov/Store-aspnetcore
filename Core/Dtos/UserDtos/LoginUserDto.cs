namespace Core.Dtos.UserDtos
{
	public class LoginUserDto
	{
		public string Token { get; set; }
		public int UserId { get; set; }
		public string? UserName { get; set; }
	}
}
