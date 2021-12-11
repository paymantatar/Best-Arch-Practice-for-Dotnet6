using Sample.Model;
using Microsoft.EntityFrameworkCore;

namespace Sample.DataAccess;

public class SampleContext : DbContext
{
	public SampleContext(DbContextOptions options) : base(options) { }

	public DbSet<Person>? People { get; set; }

	public DbSet<Employee>? Employees { get; set; }

	public DbSet<Section>? Sections { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Person>().HasData(new List<Person>
		{
			new()
			{
				Id = 1,
				Name = "Mahyar",
				Age = 29,
				Family = "Hoorbakht"
			}
		});

		modelBuilder.Entity<Section>().HasData(new List<Section>
		{
			new()
			{
				Id = 1,
				Title = "IT",
				Description = "IT"
			}
		});

		modelBuilder.Entity<Employee>().HasData(new List<Employee>
		{
			new()
			{
				Id = 1,
				PersonId = 1,
				SectionId = 1,
				HiredDate = DateTime.Now
			}
		});
	}
}
