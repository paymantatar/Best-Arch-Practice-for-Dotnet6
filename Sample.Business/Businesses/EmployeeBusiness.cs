using Sample.Business.Base;
using Sample.DataAccess;
using Sample.Model;

namespace Sample.Business.Businesses;

public class EmployeeBusiness : BaseBusiness<Employee>
{
	public EmployeeBusiness(SampleContext context) : base(context) { }
}

