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

        public async Task OnGet()
        {
            // Load the pending users
            PendingUsers =_context.User
                .Where(u => u.ProfileStatus == "Pending")
                .ToList();
        }

        // Approve Handler
        public async Task<IActionResult> OnPostApproveAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user != null)
            {
                user.ProfileStatus = "Approved";
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); // Refreshes the page to update the list
        }

        // Deny Handler
        public async Task<IActionResult> OnPostDenyAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); // Refreshes the page to update the list
        }
    }

}
