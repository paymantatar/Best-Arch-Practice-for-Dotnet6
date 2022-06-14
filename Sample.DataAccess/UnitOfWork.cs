using Sample.DataAccess.Repositories;
using Sieve.Services;

namespace Sample.DataAccess
{
	public class UnitOfWork
	{
		private readonly SampleContext _context;

		private readonly ISieveProcessor _sieveProcessor;

		public PersonRepository? personRepository;

		public EmployeeRepository? employeeRepository;

		public UnitOfWork(SampleContext sampleContext,ISieveProcessor sieveProcessor)
		{
			_context = sampleContext;
			_sieveProcessor = sieveProcessor;
		}

		public PersonRepository PersonRepository => personRepository ??= new PersonRepository(_context, _sieveProcessor);
		
		public EmployeeRepository EmployeeRepository => employeeRepository ??= new EmployeeRepository(_context, _sieveProcessor);
	
		public async Task<int> CommitAsync(CancellationToken cancellationToken = new())
		{
			// ToDo : Change LastUpdated Property Here
			return await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
