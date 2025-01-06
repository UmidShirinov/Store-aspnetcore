﻿using Core.Entities;
using Core.Repositories.Repository;

namespace Core.Repositories.UserRepository
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetByEmailAsync(string email);
		Task<bool> IsEmailTaken(string email);
	} 
}
