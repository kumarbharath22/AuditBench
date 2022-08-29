using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuditBenchmarkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditBenchmarkController : ControllerBase
    {
        private readonly IBenchmarkProvider _objProvider;
        private readonly ILogger<AuditBenchmarkController> _logger;

        public AuditBenchmarkController(IBenchmarkProvider objProvider, ILogger<AuditBenchmarkController> logger)
        {

            _objProvider = objProvider;
            _logger = logger;
        }
        [HttpGet]
        [Route("{auditType}")]
        public IActionResult GetAuditBenchmark(string auditType)
        {

            _logger.LogInformation(" Http GET request " + nameof(AuditBenchmarkController));

            if (string.IsNullOrEmpty(auditType))
            {
                _logger.LogError("Audit Type is empty");
                return BadRequest("No Input");
            }

            if ((auditType != "Internal") && (auditType != "SOX"))
            {
                _logger.LogError("Audit Type is Wrong");
                return BadRequest("Wrong Input");
            }

            //List<AuditBenchmark> listOfProvider = new List<AuditBenchmark>();
            try
            {
                var listOfProvider = _objProvider.GetBenchmark(auditType);
                return Ok(listOfProvider);
            }
            catch (Exception e)
            {
                _logger.LogError(" Exception here" + e.Message + " " + nameof(AuditBenchmarkController));
                return StatusCode(500);
            }
        }

        /* private readonly IBenchmarkProvider objProvider;
         public AuditBenchmarkController(IBenchmarkProvider _objProvider)
         {

             objProvider = _objProvider;
         }


         [HttpGet]
         public IActionResult AuditBenchmark()
         {
             List<AuditBenchmark> listOfProvider = new List<AuditBenchmark>();

             try
             {
                 listOfProvider = objProvider.GetBenchmark();
                 return Ok(listOfProvider);
             }
             catch (Exception e)
             {
                 Console.WriteLine(" Exception here" + e.Message + " " + nameof(AuditBenchmarkController));
                 return StatusCode(500);
             }
         }
        */
    }
}
