//using Hoorbakht.RedisService;
using Microsoft.EntityFrameworkCore;
using Sample.Business.Contracts;
using Sample.DataAccess;
using Sample.Model;

namespace Sample.Business.Base;

public class BaseBusiness<T> : IBusiness<T> where T : BaseEntity
{
	private readonly SampleContext _context;

	private readonly DbSet<T> _dbset;

	//private readonly IRedisService<T> _redisService;

	public BaseBusiness(SampleContext sampleContext)
	{
		_context = sampleContext;
		_dbset = _context.Set<T>();
		//_redisService = redisService;
	}

	public async Task<List<T>?> LoadAllAsync(CancellationToken cancellationToken = new()) =>
		await _dbset!.ToListAsync(cancellationToken);

	public async Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken = new())
	{
		//var cachedData = await _redisService.GetHashAsync(id.ToString());
		//if(cachedData != null) 
		//	return cachedData;
		//var data = await _dbset!.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
		//if(data == null) return null;
		//await _redisService.SetHashAsync(id.ToString(), data);
		//return data;
		return await _dbset!.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
	}

	public async Task<bool> CreateAsync(T t, CancellationToken cancellationToken = new())
	{
		try
		{
			await _dbset!.AddAsync(t, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			//await _redisService.SetHashAsync(t.Id.ToString(), t);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task<bool> UpdateAsync(T t, CancellationToken cancellationToken = new())
	{
		try
		{
			_dbset!.Update(t);
			await _context.SaveChangesAsync(cancellationToken);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = new())
	{
		try
		{
			var record = await LoadByIdAsync(id, cancellationToken);
			if (record == null) return false;
			_dbset!.Remove(record);
			await _context.SaveChangesAsync(cancellationToken);
			return true;
		}
		catch
		{
			return false;
		}
	}
}