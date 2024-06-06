using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FriendCal.Data;
using FriendCal.Models;

namespace FriendCal.Pages.Event
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CalendarEvent CalendarEvent { get; set; }

        public void OnGet(int id)
        {
            CalendarEvent = _context.CalendarEvents.Find(id);
        }

        public IActionResult OnPost()
        {
            var eventToDelete = _context.CalendarEvents.Find(CalendarEvent.Id);

            if (eventToDelete == null)
            {
                return NotFound();
            }

            _context.CalendarEvents.Remove(eventToDelete);
            _context.SaveChanges();

            return RedirectToPage("/Calendar/Index");
        }
    }
}
