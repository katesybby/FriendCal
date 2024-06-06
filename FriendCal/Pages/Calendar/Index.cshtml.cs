using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FriendCal.Data;
using FriendCal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendCal.Pages.Calendar
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<CalendarEvent> Events { get; private set; }

        public async Task OnGetAsync()
        {
            Events = await _context.CalendarEvents
                .Include(e => e.User)
                .ToListAsync();
        }
    }
}
