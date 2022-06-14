using Microsoft.EntityFrameworkCore;
using Sample.Model;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Base
{
	public class BaseRepository<T> where T : BaseEntity
	{
		private readonly SampleContext _context;
		
		private readonly ISieveProcessor _sieveProcessor;

		private readonly DbSet<T> _dbSet;

		public BaseRepository(SampleContext context, ISieveProcessor sieveProcessor)
		{
			_context = context;
			_dbSet = context.Set<T>();
			_sieveProcessor = sieveProcessor;
		}

		public async Task<T> AddAsync(T t, CancellationToken cancellationToken = new()) =>
			(await _dbSet.AddAsync(t, cancellationToken)).Entity;

		public async Task<T> UpdateAsync(T t, CancellationToken cancellationToken = new())
		{
			var response = _dbSet.Update(t).Entity;
			return await Task.FromResult(response);
			// (await _dbSet.AddAsync(t, cancellationToken)).Entity;
		}

		public async Task<T> DeleteAsync(T t, CancellationToken cancellationToken = new())
		{
			t.IsDeleted = true;
			return await UpdateAsync(t, cancellationToken);
		}

		public async Task<List<T>> LoadAll(SieveModel sieveModel, CancellationToken cancellationToken = new())
		{
			if(sieveModel.PageSize>100) sieveModel.PageSize = 100;
			var query=_dbSet.AsNoTracking();
			return await _sieveProcessor.Apply(sieveModel, query).ToListAsync(cancellationToken);
		}
	}
}
