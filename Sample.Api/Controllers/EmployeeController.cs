using Microsoft.AspNetCore.Mvc;
using Sample.Api.Contracts;
using Sample.Business.Contracts;
using Sample.Model;

namespace Sample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController : ControllerBase, IApiController<Employee>
{
	private readonly IBusiness<Employee> _business;

	public EmployeeController(IBusiness<Employee> business) =>
		_business = business;

	[HttpGet]
	[HttpHead]
	public async Task<List<Employee>?> GetAll(CancellationToken cancellationToken) =>
		await _business.LoadAllAsync(cancellationToken);

	[HttpGet]
	[Route("{id:int}")]
	public async Task<Employee?> GetById(int id, CancellationToken cancellationToken) =>
		await _business.LoadByIdAsync(id, cancellationToken);

	[HttpPut]
	public async Task<bool> Update(Employee employee, CancellationToken cancellationToken) =>
		await _business.UpdateAsync(employee, cancellationToken);

	[HttpPost]
	public async Task<bool> Add(Employee employee, CancellationToken cancellationToken) =>
		await _business.CreateAsync(employee, cancellationToken);

	[HttpDelete, Route("{id:int}")]
	public async Task<bool> Delete(int id, CancellationToken cancellationToken) =>
		await _business.DeleteAsync(id, cancellationToken);

	[HttpOptions]
	public void Options() =>
		Response.Headers.Add("Allow", "POST,OPTIONS,GET,PUT,DELETE,HEAD");
}