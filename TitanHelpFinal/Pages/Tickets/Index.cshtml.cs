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
    public class IndexModel : PageModel
    {
        private readonly TitanHelpFinal.Data.TicketContext _context;

        public IndexModel(TitanHelpFinal.Data.TicketContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ticket = await _context.Ticket.ToListAsync();
        }
    }
}
