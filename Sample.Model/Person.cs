namespace Sample.Model;

public class Person : BaseEntity
{
	public string? Name { get; set; }

	public string? Family { get; set; }

	public string FullName => Name + " " + Family;

	public short Age { get; set; }
}

