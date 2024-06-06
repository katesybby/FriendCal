using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FriendCal.Data;
using FriendCal.Models;
using System.Linq;

namespace FriendCal.Pages.Event
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var eventToUpdate = _context.CalendarEvents.SingleOrDefault(e => e.Id == CalendarEvent.Id);

            if (eventToUpdate == null)
            {
                return NotFound();
            }

            eventToUpdate.Date = CalendarEvent.Date;
            eventToUpdate.Title = CalendarEvent.Title;
            eventToUpdate.Location = CalendarEvent.Location;

            _context.SaveChanges();

            return RedirectToPage("/Calendar/Index");
        }
    }
}
