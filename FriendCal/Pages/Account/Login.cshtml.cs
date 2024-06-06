using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FriendCal.Data;
using System.Linq;

namespace FriendCal.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.Users.SingleOrDefault(u => u.Username == Input.Username && u.Password == Input.Password);

            if (user != null)
            {
                // Authentication successful
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }

        public class LoginInputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
