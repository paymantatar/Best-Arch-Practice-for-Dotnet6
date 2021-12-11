using Microsoft.EntityFrameworkCore;
using Sample.Business.Contracts;
using Sample.DataAccess;
using Sample.Model;

namespace Sample.Business.Base;

public class BaseBusiness<T> : IBusiness<T> where T : BaseEntity
{
	private readonly SampleContext _context;

	private readonly DbSet<T> _dbset;

	public BaseBusiness(SampleContext sampleContext)
	{
		_context = sampleContext;
		_dbset = _context.Set<T>();
	}

	public async Task<List<T>?> LoadAllAsync(CancellationToken cancellationToken = new()) =>
		await _dbset!.ToListAsync(cancellationToken);

	public async Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken = new()) =>
		await _dbset!.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

	public async Task<bool> CreateAsync(T t, CancellationToken cancellationToken = new())
	{
		try
		{
			await _dbset!.AddAsync(t, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
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