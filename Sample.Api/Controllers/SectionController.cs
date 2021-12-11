using Microsoft.AspNetCore.Mvc;
using Sample.Api.Contracts;
using Sample.Business.Contracts;
using Sample.Model;

namespace Sample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionController : ControllerBase, IApiController<Section>
{
	private readonly IBusiness<Section> _business;

	public SectionController(IBusiness<Section> business) =>
		_business = business;

	[HttpGet]
	[HttpHead]
	public async Task<List<Section>?> GetAll(CancellationToken cancellationToken) =>
		await _business.LoadAllAsync(cancellationToken);

	[HttpGet]
	[Route("{id:int}")]
	public async Task<Section?> GetById(int id, CancellationToken cancellationToken) =>
		await _business.LoadByIdAsync(id, cancellationToken);

	[HttpPut]
	public async Task<bool> Update(Section section, CancellationToken cancellationToken) =>
		await _business.UpdateAsync(section, cancellationToken);

	[HttpPost]
	public async Task<bool> Add(Section section, CancellationToken cancellationToken) =>
		await _business.CreateAsync(section, cancellationToken);

	[HttpDelete, Route("{id:int}")]
	public async Task<bool> Delete(int id, CancellationToken cancellationToken) =>
		await _business.DeleteAsync(id, cancellationToken);

	[HttpOptions]
	public void Options() =>
		Response.Headers.Add("Allow", "POST,OPTIONS,GET,PUT,DELETE,HEAD");
}

