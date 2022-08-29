using AuditBenchmarkModule.Data;
using AuditBenchmarkModule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public class BenchmarkRepo : IBenchmarkRepo
    {
        private readonly BenchmarkContext _context;
        private readonly ILogger<BenchmarkRepo> _logger;
        private NullLogger<BenchmarkRepo> nullLogger;

        public BenchmarkRepo(NullLogger<BenchmarkRepo> nullLogger)
        {
            this.nullLogger = nullLogger;
        }

        public BenchmarkRepo(BenchmarkContext context, ILogger<BenchmarkRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

      

        /*
        public async Task<List<AuditBenchmark>> AuditBenchmarkListAsync()
        {
            try
            {
                var records = await _context.BenchmarkLists.Select(x => new AuditBenchmark
                {
                    auditType = x.auditType,
                    benchmarkNoAnswers = x.benchmarkNoAnswers

                }).ToListAsync();

                return records;
            }
            catch (Exception e)
            {
                Console.WriteLine(" Exception here" + e.Message + " " + nameof(BenchmarkRepo));
                return null;
            }
        }
        */

        public AuditBenchmark GetNolist(string auditType)
        {
            _logger.LogInformation(" Http GET request " + nameof(BenchmarkRepo));

            if (string.IsNullOrEmpty(auditType))
            {
                _logger.LogError("Audit Type is empty");
                return null;
            }

            if ((auditType != "Internal") && (auditType != "SOX"))
            {
                _logger.LogError("Audit Type is Wrong");
                return null;
            }

            try
            {
                _logger.LogInformation("Getting BenchmarknoList");
                var records = _context.BenchmarkLists.Select(x => new AuditBenchmark 
                { auditType = x.auditType, benchmarkNoAnswers = x.benchmarkNoAnswers }).FirstOrDefault(); 
                return records;//throw new NotImplementedException();
            }
            catch (Exception e)
            {
                _logger.LogError(" Exception here" + e.Message + " " + nameof(BenchmarkRepo));
                return null;
            }
        }

        //return Dbc.QuestionList.Where((e) => e.QuestionType.Equals(auditType)).ToList();
        /*
        private static List<AuditBenchmark> AuditBenchmarkList = new List<AuditBenchmark>()
        {
            new AuditBenchmark
            {
                auditType="Internal",
                benchmarkNoAnswers=3
            },
            new AuditBenchmark
            {
                auditType="SOX",
                benchmarkNoAnswers=1
            }
        };
       
        public List<AuditBenchmark> GetNolist()
        {
          
            List<AuditBenchmark> listOfCriteria = new List<AuditBenchmark>();
            try
            {
                listOfCriteria = AuditBenchmarkList;
                return listOfCriteria;
            }
            catch (Exception e)
            {
                Console.WriteLine(" Exception here" + e.Message + " " + nameof(BenchmarkRepo));
                return null;
            }

        }
        */
    }
}
