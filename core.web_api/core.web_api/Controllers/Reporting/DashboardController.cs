using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modeli.trading.Dashboard;
using servisi.trading.Repos.Dashboard;

namespace core.web_api.Controllers.Reporting
{
    [Route("[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ReportingServis reportingServis;

        public DashboardController(ReportingServis reportingServis)
        {
            this.reportingServis = reportingServis;
        }

        [HttpGet("GetReport")]
        public async Task<Report> GetReport()
        {
            return await reportingServis.GetReport();
        }

    }
}
