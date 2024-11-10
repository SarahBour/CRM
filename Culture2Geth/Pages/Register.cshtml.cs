using Culture2Geth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string MembershipType { get; set; }

        [BindProperty]
        public List<string> Interests { get; set; } = new List<string>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Create a new user
                var user = new User
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,  
                    Address = Address,
                    PhoneNumber = PhoneNumber,
                    MembershipType = MembershipType,
                    Role = "Member",
                    ProfileStatus = "Pending"
                };

                // Save the user to the database
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                // Add selected interests to the User
                foreach (var interestName in Interests)
                {
                    var interest = await _context.Interest
                        .FirstOrDefaultAsync(i => i.Name == interestName);

                    if (interest == null)
                    {
                        // If the interest does not exist, create it
                        interest = new Interest { Name = interestName };
                        _context.Interest.Add(interest);
                        await _context.SaveChangesAsync();
                    }

                    // Create a relationship between the user and the interest
                    _context.UserInterest.Add(new UserInterest
                    {
                        UserId = user.UserId,
                        InterestID = interest.InterestID
                    });
                }

                // Save the changes to the relationships
                await _context.SaveChangesAsync();

                return RedirectToPage("Success");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                // For example, log the error message (you could log to a file, or handle it differently)
                Debug.WriteLine(error.ErrorMessage);
            }
            return Page();
        }
    }
}



// include cannot create a profile with existing email 
// include password hashing 
// maybe add password strength 
// the phone number should be valid 
// the address should be valid 

// you can save user data after each step



