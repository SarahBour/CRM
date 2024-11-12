using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Culture2Geth.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Diagnostics;

namespace Culture2Geth.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDBContext _context;

		public IndexModel(ApplicationDBContext context)
		{
			_context = context;
		}
		[BindProperty]
		public string Email { get; set; }

		[BindProperty]
		public string Password { get; set; }

		public async Task<IActionResult> OnPostAsync(string Email, string Password)
		{
			var user = await _context.User.FirstOrDefaultAsync(u => u.Email == Email);
            if (user != null && Password == user.Password && user.ProfileStatus == "Approved")
			{
                if (user.Role == "Admin")
				{
					return RedirectToPage("Admin");
				}
				else if(user.Role == "Member")
				{
					return RedirectToPage("Member");

				}
			}
			else if(user == null)
			{
				ModelState.AddModelError(String.Empty, "Email incorrect or doesn't exist");
			}
			else if(Password != user.Password)
			{
				ModelState.AddModelError(String.Empty, "Incorrect password");
			}
			else if(user.ProfileStatus != "Approved")
			{
				return RedirectToPage("Success");
			}
			return Page();
		}
	}
}
// Later: BCrypt.Net.BCrypt.Verify(Password, user.Password) 