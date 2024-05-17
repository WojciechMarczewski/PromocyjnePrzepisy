using PromocyjnePrzepisy.Services.Interfaces;

namespace PromocyjnePrzepisy.Models
{
    public class Report
    {

        public Report(ReportType type, string body)
        {
            ReportType = type;
            Body = body;
        }

        public ReportType ReportType { get; set; }
        public string Body { get; set; }

    }
}
