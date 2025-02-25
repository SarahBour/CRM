using Culture2Geth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

// register class, this is the logic behind the html file 

namespace Culture2Geth.Pages
{
    public class RegisterModel : PageModel
    {
        // linking the database 

        private readonly ApplicationDBContext _context;

        public RegisterModel(ApplicationDBContext context)
        {
            _context = context;
        }
        // Storing the data + data validation 

        [BindProperty]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be under 50 characters.")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be under 50 characters.")]
        public string LastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage= "Password must be at least 8 characters long and include at least one uppercase letter," +
            " one lowercase letter, one number, and one special character (e.g., @$!%*?&).")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please confirm your password.")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Address is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z0-9\s,.'-]{10,}$", ErrorMessage = "Please enter a valid address.")]
        public string Address { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Please enter a valid phone number (10-15 digits).")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string MembershipType { get; set; }

        [BindProperty]
        public List<string> Interests { get; set; } = new List<string>();

        [BindProperty]
        [Required(ErrorMessage = "Please select if you'd like to receive emails.")]
        public int MailingList { get; set; }





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
                // hashing password for security :)
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
                var user = new User
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = hashedPassword,  
                    Address = Address,
                    PhoneNumber = PhoneNumber,
                    MembershipType = MembershipType,
                    JoinDate= DateTime.Now,
                    ExpiryDate = DateTime.Now.AddYears(1),
                    Role = "Member",
                    ProfileStatus = "Pending",
                    MailingList = MailingList
                };

                _context.User.Add(user);
                await _context.SaveChangesAsync();

                // linking the interests with users in the UserInterest table 
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

                // if successful, redirect to this page to inform the user that it was! 
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





