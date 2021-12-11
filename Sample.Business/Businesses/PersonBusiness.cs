using Sample.Business.Base;
using Sample.DataAccess;
using Sample.Model;

namespace Sample.Business.Businesses;

public class PersonBusiness : BaseBusiness<Person>
{
	public PersonBusiness(SampleContext context) : base(context) { }
}

