using Sample.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Sample.DataAccess;

public class SampleContext : DbContext
{
	public SampleContext(DbContextOptions options) : base(options) { }

	public DbSet<Person>? People { get; set; }

	public DbSet<Employee>? Employees { get; set; }

	public DbSet<Section>? Sections { get; set; }

	//public override EntityEntry Remove(object entity)
	//{
	//	var ob = entity as EntityEntry;
	//	ob.Properties.Single(x=>x.)
	//}

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

		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			if (entityType.GetProperties().All(x => x.Name != "IsDeleted"))
				continue;

			entityType.GetProperty("IsDeleted");

			var parameter = Expression.Parameter(entityType.ClrType);

			var propertyMethodInfo = typeof(EF).GetMethod("Property")?.MakeGenericMethod(typeof(bool));
			var isDeletedProperty = Expression.Call(propertyMethodInfo!, parameter, Expression.Constant("IsDeleted"));

			var compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

			var lambda = Expression.Lambda(compareExpression, parameter);

			modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
		}
	}
}
