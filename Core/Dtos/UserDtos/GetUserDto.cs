﻿namespace Core.Dtos.UserDtos
{
	public class GetUserDto
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
	}
}
