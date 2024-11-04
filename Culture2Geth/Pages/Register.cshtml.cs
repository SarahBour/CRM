using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Culture2Geth.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
		public string LastName { get; set; }
		[BindProperty]
		public string Email { get; set; }
		[BindProperty]
		public string Password { get; set; }
		[BindProperty]
		public string Address { get; set; }
		[BindProperty]
		public string PhoneNumber { get; set; }
		[BindProperty]
		public string MembershipType { get; set; }
		[BindProperty]
		public string Interests { get; set; }
		[BindProperty]
		public string ProfileStatus { get; set; }
		[BindProperty]
		public int CurrentStep { get; set; } = 1;


		public async Task<IActionResult> OnPostAsync(string nextStep,string prevStep, string submit)
		{
			if (!string.IsNullOrEmpty(nextStep))
			{
				CurrentStep = 2;
			}
			else if (!string.IsNullOrEmpty(prevStep))
			{
				CurrentStep = 1;
			}
			else if(!string.IsNullOrEmpty(submit) && ModelState.IsValid)
			{
				return RedirectToPage("Home");
			}
			return Page();
		}

	}
}
