namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface ISupportService
    {
        public Task SendReportAsync(ReportType type, string content);
    }
    public enum ReportType
    {
        Feedback,
        Bug
    }
}
