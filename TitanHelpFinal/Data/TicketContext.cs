using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TitanHelpFinal.Models;

namespace TitanHelpFinal.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext (DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public DbSet<TitanHelpFinal.Models.Ticket> Ticket { get; set; } = default!;
    }
}
