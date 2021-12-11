namespace Sample.Model;

public class Section : BaseEntity
{
	public string? Title { get; set; }

	public string? Description { get; set; }

	public virtual ICollection<Employee>? Employees { get; set; }
}

