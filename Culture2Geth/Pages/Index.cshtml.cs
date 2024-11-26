using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Culture2Geth.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Diagnostics;

namespace Culture2Geth.Pages
{
	// login class, logic behind the html form 
	public class IndexModel : PageModel
	{
		// connecting with the database 
		private readonly ApplicationDBContext _context;

		public IndexModel(ApplicationDBContext context)
		{
			_context = context;
		}

		// getting the data 
		[BindProperty]
		public string Email { get; set; }

		[BindProperty]
		public string Password { get; set; }

		public async Task<IActionResult> OnPostAsync(string Email, string Password)
		{
			// find the user in the database 
			var user = await _context.User.FirstOrDefaultAsync(u => u.Email == Email);

			// verifying that the password is correct, and that the user is either a member or an admin, not an external person 
            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Password) && user.ProfileStatus == "Approved")
			{
				// if the user is an admin 
                if (user.Role == "Admin")
				{
					return RedirectToPage("Admin");
				}

				// if the user is a member 
				else if(user.Role == "Member")
				{
					return RedirectToPage("Member");

				}
			}

			// validation errors 
			else if(user == null)
			{
				ModelState.AddModelError(String.Empty, "Email incorrect or doesn't exist");
			}
			else if(Password != user.Password)
			{
				ModelState.AddModelError(String.Empty, "Incorrect password");
			}

			// remind the user that they still cannot login, they are waiting for approval.
			else if(user.ProfileStatus != "Approved")
			{
				return RedirectToPage("Success");
			}
			return Page();
		}
	}
}
