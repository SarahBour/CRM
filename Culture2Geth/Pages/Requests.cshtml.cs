using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Culture2Geth.Models; 
using System.Linq;
using Culture2Geth.Models;

namespace Culture2Geth.Pages
{
    public class RequestsModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public RequestsModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<User> PendingUsers { get; set; }

        // get a list of the users with status pending 
        public async Task OnGet()
        {
            PendingUsers =_context.User
                .Where(u => u.ProfileStatus == "Pending")
                .ToList();
        }

        // if the admin clicks on approve 
        public async Task<IActionResult> OnPostApproveAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            // change the status to approved 
            if (user != null)
            {
                user.ProfileStatus = "Approved";
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); 
        }

        // if the admin clicks on deny 
        public async Task<IActionResult> OnPostDenyAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            // remove user from the database 
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); 
        }
    }

}
