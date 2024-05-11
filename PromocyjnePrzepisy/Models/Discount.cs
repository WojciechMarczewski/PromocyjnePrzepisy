namespace PromocyjnePrzepisy.Models
{
    public class Discount(DateOnly startDate, DateOnly endDate)
    {
        public DateOnly StartDate { get; set; } = startDate;
        public DateOnly EndDate { get; set; } = endDate;
    }
}