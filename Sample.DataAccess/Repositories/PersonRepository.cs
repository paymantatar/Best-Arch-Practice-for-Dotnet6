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
	public class PersonRepository : BaseRepository<Person>
	{
		public PersonRepository(SampleContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
		{
		}
	}
}
