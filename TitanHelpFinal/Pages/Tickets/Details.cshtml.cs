using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TitanHelpFinal.Data;
using TitanHelpFinal.Models;

namespace TitanHelpFinal.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly TitanHelpFinal.Data.TicketContext _context;

        public DetailsModel(TitanHelpFinal.Data.TicketContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                Ticket = ticket;
            }
            return Page();
        }
    }
}
