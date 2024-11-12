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
            // chekcing for validation 
            if(await _context.User.AnyAsync(u => u.Email == Email))
            {
                ModelState.AddModelError("Email", "An account with this email already exists.");
            }
            if(await _context.User.AnyAsync(u => u.PhoneNumber == PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "An account with this phone number already exists.");
            }
            if(Password != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords don't match");
            }

            // if everything is good, create the user 
            if (ModelState.IsValid)
            {
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

                _context.User.Add(user);
                await _context.SaveChangesAsync();

                foreach (var interestName in Interests)
                {
                    var interest = await _context.Interest
                        .FirstOrDefaultAsync(i => i.Name == interestName);

                    if (interest == null)
                    {
                        interest = new Interest { Name = interestName };
                        _context.Interest.Add(interest);
                        await _context.SaveChangesAsync();
                    }

                    _context.UserInterest.Add(new UserInterest
                    {
                        UserId = user.UserId,
                        InterestID = interest.InterestID
                    });
                }

                await _context.SaveChangesAsync();

                return RedirectToPage("Success");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Debug.WriteLine(error.ErrorMessage);
            }
            return Page();
        }
    }
}



// Later2: include password hashing 
// maybe add password strength 
// Later1: check for intial membership type :) 




