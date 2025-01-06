namespace Core.Dtos.UserDtos
{
	public class CreateUserDto
	{
		public string Name { get; set; } 
		public string Email { get; set; } 
		public string PasswordHash { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
