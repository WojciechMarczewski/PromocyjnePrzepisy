namespace PromocyjnePrzepisy.Models
{
    public class Discount(DateOnly startDate, DateOnly endDate) : EntityBase
    {
        public DateOnly StartDate { get; set; } = startDate;
        public DateOnly EndDate { get; set; } = endDate;
    }
}