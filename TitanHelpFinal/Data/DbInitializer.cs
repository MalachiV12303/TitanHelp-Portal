using TitanHelpFinal.Models;

namespace TitanHelpFinal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TicketContext context)
        {
            // Look for any students.
            if (context.Tickets.Any())
            {
                return;   // DB has been seeded
            }

            var tickets = new Ticket[]
            {
                new Ticket{Name="Carson",ProblemDescription="Printer not working",SubmittedDate=DateTime.Parse("2019-09-01")},
                new Ticket{Name="Meredith",ProblemDescription="POS system not working",SubmittedDate=DateTime.Parse("2017-09-01")},
                new Ticket{Name="Arturo",ProblemDescription="Leaking",SubmittedDate=DateTime.Parse("2018-09-01")},
                new Ticket{Name="Gytis",ProblemDescription="Auto-generated Ticket, please accept",SubmittedDate=DateTime.Parse("2017-09-01")},
                new Ticket{Name="Yan",ProblemDescription="Student unable to enroll",SubmittedDate=DateTime.Parse("2017-09-01")},
                new Ticket{Name="Peggy",ProblemDescription="Ticket ticket ticket ticket?",SubmittedDate=DateTime.Parse("2016-09-01")},
                new Ticket{Name="Laura",ProblemDescription="Cannot see where I am going",SubmittedDate=DateTime.Parse("2018-09-01")},
                new Ticket{Name="Nino",ProblemDescription="Restock the fridge",SubmittedDate=DateTime.Parse("2019-09-01")}
            };

            context.Tickets.AddRange(tickets);
            context.SaveChanges();

        }
    }
}