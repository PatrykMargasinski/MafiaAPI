using MafiaAPI.Models;

namespace MafiaAPI.Services.Messages
{
    public interface IReportService
    {
        public void CreateReport(Report report);
        public void CreateReport(long toBossId, string subject, string content);
    }
}
