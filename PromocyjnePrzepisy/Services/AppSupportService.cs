using PromocyjnePrzepisy.HttpServices;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Diagnostics;

namespace PromocyjnePrzepisy.Services
{
    public class AppSupportService : ISupportService
    {
        private readonly HttpService _httpService;
        public AppSupportService(HttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task SendReportAsync(ReportType type, string content)
        {
            Report report = new Report(type, content);
            try
            {
                await _httpService.SendReportAsync(report);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
