using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Player")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportRepository _reportRepository;
        private readonly ISecurityService _securityService;

        public ReportController(IReportRepository reportRepository, ISecurityService securityService)
        {
            _reportRepository = reportRepository;
            _securityService = securityService;
        }

        [HttpGet("to")]
        public JsonResult GetAllReportsTo(long bossId, int? fromRange, int? toRange,  bool onlyUnseen = false)
        {

            if (!fromRange.HasValue || !toRange.HasValue)
            {
                fromRange = 0; toRange = 5;
            }

            var reports = _reportRepository
                .GetAllReportsTo(bossId, fromRange.Value, toRange.Value,  onlyUnseen)
                .Select(x => new
                {
                    x.Id,
                    ToBoss = x.ToBoss.FirstName + " " + x.ToBoss.LastName,
                    Subject = _securityService.Decrypt(x.Subject),
                    ReceivedDate = x.ReceivedDate,
                    Seen = x.Seen
                }
                );
            return new JsonResult(reports);
        }

        [HttpGet("count")]
        public JsonResult CountReportsTo(long bossId)
        {
            var reportCount = _reportRepository.CountReportsTo(bossId);
            return new JsonResult(reportCount);
        }

        [HttpGet("content")]
        public JsonResult GetReportContent(int id)
        {
            var report = _reportRepository.GetById(id);
            report.Seen = true;
            _reportRepository.Update(report);
            var content = _securityService.Decrypt(report.Subject) + "\n\n" +
                _securityService.Decrypt(report.Content);
            return new JsonResult(content);
        }

        [HttpPost]
        public JsonResult CreateReport(Report report)
        {
            report.Subject = _securityService.Encrypt(report.Subject);
            report.Content = _securityService.Encrypt(report.Content);
            report.ReceivedDate = DateTime.Now;
            _reportRepository.Create(report);
            return new JsonResult("Added successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteReport(int id)
        {
            _reportRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }

        [Route("/reports")]
        [HttpDelete]
        public JsonResult DeleteReports(string stringIds)
        {
            long[] ids = stringIds.Split('i').Select(x => long.Parse(x)).ToArray();
            _reportRepository.DeleteByIds(ids);
            return new JsonResult("Deleted successfully");
        }
    }
}
