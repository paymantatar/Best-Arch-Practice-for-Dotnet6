using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Model;

public class Employee : BaseEntity
{
	public Employee() => 
		HiredDate = DateTime.Now;

	public int PersonId { get; set; }

	[ForeignKey("PersonId")]
	public Person? Person { get; set; }

	public int SectionId { get; set; }

	[ForeignKey("SectionId")]
	public Section? Section { get; set; }

	public DateTime HiredDate { get; set; }
}

