using Sample.Model;

namespace Sample.Business.Contracts;

public interface IBusiness<T> where T : BaseEntity
{
	Task<List<T>?> LoadAllAsync(CancellationToken cancellationToken = new());

	Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken = new());

	Task<bool> CreateAsync(T t, CancellationToken cancellationToken = new());

	Task<bool> UpdateAsync(T t, CancellationToken cancellationToken = new());

	Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = new());
}