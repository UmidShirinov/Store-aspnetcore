﻿using Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Repository
{
	public class Repository<T>:IRepository<T> where T: class
	{
		protected readonly ApplicationDbContext _context;
		protected readonly DbSet<T> _dbSet;

		public Repository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

		public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

		public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

		public void Update(T entity) => _dbSet.Update(entity);

		public void Delete(T entity) => _dbSet.Remove(entity);

		public async Task SaveAsync() => await _context.SaveChangesAsync();

	}
}
