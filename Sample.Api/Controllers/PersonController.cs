using Microsoft.AspNetCore.Mvc;
using Sample.Api.Contracts;
using Sample.Business.Contracts;
using Sample.Model;

namespace Sample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase, IApiController<Person>
{
	private readonly IBusiness<Person> _business;

	public PersonController(IBusiness<Person> business) =>
		_business = business;

	[HttpGet]
	[HttpHead]
	public async Task<List<Person>?> GetAll(CancellationToken cancellationToken) =>
		await _business.LoadAllAsync(cancellationToken);

	[HttpGet]
	[Route("{id:int}")]
	public async Task<Person?> GetById(int id, CancellationToken cancellationToken) =>
		await _business.LoadByIdAsync(id, cancellationToken);

	[HttpPut]
	public async Task<bool> Update(Person person, CancellationToken cancellationToken) =>
		await _business.UpdateAsync(person, cancellationToken);

	[HttpPost]
	public async Task<bool> Add(Person person, CancellationToken cancellationToken) =>
		await _business.CreateAsync(person, cancellationToken);

	[HttpDelete, Route("{id:int}")]
	public async Task<bool> Delete(int id, CancellationToken cancellationToken) =>
		await _business.DeleteAsync(id, cancellationToken);

	[HttpOptions]
	public void Options() =>
		Response.Headers.Add("Allow", "POST,OPTIONS,GET,PUT,DELETE,HEAD");
}
