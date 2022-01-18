using Sieve.Attributes;
namespace Sample.Model;

public class Person : BaseEntity
{
	[Sieve(CanFilter = true)]
	public string? Name { get; set; }

	[Sieve(CanFilter = true, CanSort = true)]
	public string? Family { get; set; }

	public string FullName => Name + " " + Family;

	[Sieve(CanSort = true)]
	public short Age { get; set; }
}

