using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sample.Web.Pages.People;

public class EditModel : PageModel
{
	[BindProperty(SupportsGet = true)]
	public int PersonId { get; set; }
	
	public void OnGet()
	{
	}
}
