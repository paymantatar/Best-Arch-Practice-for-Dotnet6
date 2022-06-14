using Sample.DataAccess.Base;
using Sample.Model;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories
{
	public class EmployeeRepository : BaseRepository<Employee>
	{
		public EmployeeRepository(SampleContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
		{
		}
	}
}
