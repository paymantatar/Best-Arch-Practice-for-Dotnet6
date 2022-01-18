using Sample.DataAccess;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Sample.Business.Businesses;
using Sample.Api.Contracts;
using Sample.Business.Contracts;
using Sample.Model;
//using Hoorbakht.RedisService;
//using Hoorbakht.RedisService.Contracts;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddRazorPages()
	.Services
	.AddControllers()
	.AddApplicationPart(typeof(IApiController<>).Assembly)
	.Services
	.AddHealthChecks()
	.Services
	.AddDbContext<SampleContext>(option => option.UseInMemoryDatabase("Sample"))
	.AddScoped<ISieveProcessor, SieveProcessor>()
	.AddScoped<UnitOfWork>()
	.AddScoped<IBusiness<Person>, PersonBusiness>()
	.AddScoped<IBusiness<Employee>, EmployeeBusiness>()
	.AddScoped<IBusiness<Section>, SectionBusiness>()
	.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.Api", Version = "v1" }));
	//.AddTransient<IRedisService<Person>>(_ => new RedisService<Person>(new RedisConfiguration(-1, "Sample", "localhost:6379"), "Person"))
	//.AddTransient<IRedisService<Employee>>(_ => new RedisService<Employee>(new RedisConfiguration(-1, "Sample", "localhost:6379"), "Employee"))
	//.AddTransient<IRedisService<Section>>(_ => new RedisService<Section>(new RedisConfiguration(-1, "Sample", "localhost:6379"), "Section"));

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();

await using var context = scope.ServiceProvider.GetRequiredService<SampleContext>();

await context.Database.EnsureCreatedAsync();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
						"Swagger Demo API v1"));

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.MapHealthChecks("HealthCkecks");

await app.RunAsync();
