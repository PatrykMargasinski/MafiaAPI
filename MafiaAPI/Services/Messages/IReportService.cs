using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Services.Messages
{
    public interface IReportService
    {
        public void CreateReport(Report report);
        public void CreateReport(long toBossId, string subject, string content);
    }
}
