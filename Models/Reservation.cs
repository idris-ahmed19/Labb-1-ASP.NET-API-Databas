namespace Labb_1_ASP.NET_API___Databas.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfCustomers { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
