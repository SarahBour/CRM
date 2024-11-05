using Culture2Geth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Culture2Geth.Pages
{
    public class RegisterModel : PageModel
    {
		private readonly ApplicationDBContext _context;
		public RegisterModel(ApplicationDBContext context)
		{
			_context = context;
		}

		[BindProperty]
		public string FirstName { get; set; }
		[BindProperty]
		public string LastName { get; set; }
		[BindProperty]
		public string Email { get; set; }
		[BindProperty]
		public string Password { get; set; }
		[BindProperty]
		public string ConfirmPassword { get; set; }
		[BindProperty]
		public string Address { get; set; }
		[BindProperty]
		public int PhoneNumber { get; set; }
		[BindProperty]
		public string nextStep { get; set; }
		[BindProperty]
		public string MembershipType { get; set; }
		[BindProperty]
		public List<string> Interests { get; set; }
		[BindProperty]
		public string prevStep { get; set; }
		[BindProperty]
		public string submit { get; set; }


		public int CurrentStep { get; set; } = 1;


		public async Task<IActionResult> OnPostAsync(string nextStep,string prevStep, string submit)
		{
			// Handle step navigation
			if (!string.IsNullOrEmpty(nextStep))
			{
				// Validate inputs for Step 1 before moving to Step 2
				if (CurrentStep == 1 && !ModelState.IsValid)
				{
					return Page(); // Stay on Step 1 if validation fails
				}

				// Move to Step 2 if validation passes
				CurrentStep = 2;
			}
			else if (!string.IsNullOrEmpty(prevStep))
			{
				CurrentStep = 1; // Go back to Step 1
			}
			else if (!string.IsNullOrEmpty(submit))
			{
				// Validate the final submission
				if (!ModelState.IsValid)
				{
					return Page(); // Stay on the current step if validation fails
				}

				// Check if passwords match
				if (Password != ConfirmPassword)
				{
					ModelState.AddModelError(nameof(ConfirmPassword), "Passwords do not match.");
					return Page(); // Stay on the current step if passwords don't match
				}

				// Save the user data
				var user = new User
				{
					FirstName = FirstName,
					LastName = LastName,
					Email = Email,
					Password = Password,
					Address = Address,
					PhoneNumber = PhoneNumber,
					MembershipType = MembershipType,
				};
				_context.User.Add(user);
				await _context.SaveChangesAsync();
				CurrentStep = 3; // Move to Step 3 after successful submission
			}

			return Page(); // Return to the page to preserve the current step and input values
		}

	}
}
// include cannot create a profile with existing email 
// include password hashing 
// maybe add password strength 
// the phone number should be valid 
// the address should be valid 



