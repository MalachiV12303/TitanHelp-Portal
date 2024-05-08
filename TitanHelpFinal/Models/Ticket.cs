namespace TitanHelpFinal.Models
{
    public class Ticket
    {
        public int TicketNum { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProblemDescription { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }

    }
}