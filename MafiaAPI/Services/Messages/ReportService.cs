using MafiaAPI.Models;
using MafiaAPI.Repositories;
using System;

namespace MafiaAPI.Services.Messages
{

    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ISecurityService _securityService;
        public ReportService(IReportRepository reportRepository, IBossRepository bossRepository, ISecurityService securityService)
        {
            _reportRepository = reportRepository;
            _securityService = securityService;
        }
        public void CreateReport(Report report)
        {
            report.Content = _securityService.Encrypt(report.Content);
            _reportRepository.Create(report);
        }
        public void CreateReport(long toBossId, string subject, string content)
        {
            Report report = new Report()
            {
                ToBossId = toBossId,
                Subject = _securityService.Encrypt(subject),
                Content = _securityService.Encrypt(content),
                ReceivedDate = DateTime.Now,
                Seen = false
            };
            _reportRepository.Create(report);
        }
    }
}
