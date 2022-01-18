using Hoorbakht.RedisService;
using Sample.Business.Base;
using Sample.DataAccess;
using Sample.Model;

namespace Sample.Business.Businesses;

public class EmployeeBusiness : BaseBusiness<Employee>
{
	public EmployeeBusiness(SampleContext context) : base(context) { }
	//public EmployeeBusiness(SampleContext context, IRedisService<Employee> redisService) : base(context, redisService) { }
}

