using Sample.Model;

namespace Sample.Api.Contracts;

public interface IApiController<T> where T : BaseEntity
{
	Task<List<T>?> GetAll(CancellationToken cancellationToken);

	Task<T?> GetById(int id, CancellationToken cancellationToken);

	Task<bool> Update(T t, CancellationToken cancellationToken);

	Task<bool> Add(T t, CancellationToken cancellationToken);
		
	Task<bool> Delete(int id, CancellationToken cancellationToken);

	void Options();
}
