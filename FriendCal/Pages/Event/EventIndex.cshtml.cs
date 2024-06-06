using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FriendCal.Data;
using FriendCal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendCal.Pages.Event
{
    public class EventIndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public EventIndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<CalendarEvent> Events { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.CalendarEvents.ToListAsync();
        }
    }
}
