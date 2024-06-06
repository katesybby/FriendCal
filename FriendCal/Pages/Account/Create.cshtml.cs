using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FriendCal.Models;
using FriendCal.Data;

namespace FriendCal.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Input { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User newUser = new User
            {
                Name = Input.Name,
                Username = Input.Username,
                Password = Input.Password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}
