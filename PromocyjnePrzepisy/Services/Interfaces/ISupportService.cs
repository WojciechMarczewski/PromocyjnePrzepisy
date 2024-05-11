namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface ISupportService
    {
        public void SendTicket(TicketType type, string content);
    }
    public enum TicketType
    {
        Feedback,
        Bug
    }
}
