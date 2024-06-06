using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FriendCal.Data;
using FriendCal.Models;


namespace FriendCal.Pages.Event
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CalendarEvent CalendarEvent { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CalendarEvents.Add(CalendarEvent);
            _context.SaveChanges();

            return RedirectToPage("/Calendar/Index");
        }
    }
}
