using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Providers
{
    public class BenchmarkProvider : IBenchmarkProvider
    {
        private readonly IBenchmarkRepo objBenchmarkRepo;
        private readonly ILogger<BenchmarkProvider> _logger;

        public BenchmarkProvider(IBenchmarkRepo _objBenchmarkRepo, ILogger<BenchmarkProvider> logger)
        {

            objBenchmarkRepo = _objBenchmarkRepo;
            _logger = logger;
        }

        public AuditBenchmark GetBenchmark(string auditType)
        {
            _logger.LogInformation(" Http GET request " + nameof(BenchmarkProvider));

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


            //List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                var listOfRepository = objBenchmarkRepo.GetNolist(auditType);
                return listOfRepository;
                /*if(listOfRepository!=null)
                    return listOfRepository;
                else
                    return null;*/
            }
            catch (Exception e)
            {
                _logger.LogError(" Exception here" + e.Message + " " + nameof(BenchmarkProvider));
                return null;
            }

        }




    }
}
/*
 public List<AuditBenchmark> GetBenchmark()
        {
            _log4net.Info(" Http GET request " + nameof(BenchmarkProvider));

            List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(BenchmarkProvider));
                return null;
            }

        }
*/

/*
 * List<Questions> list = new List<Questions>();

        public dynamic QuestionsProvider(string type)
        {
            if (string.IsNullOrEmpty(type))
                return null;

            else if (!type.Contains("Internal") && !type.Contains("SOX"))
                return null;
            
            try
            {
                list = obj.GetQuestions(type);
                return list;
            }
            catch(Exception)
            {
                return null;
            }
            
            
        }

 private List<AuditBenchmark> listOfRepository;

        public List<AuditBenchmark> GetBenchmark()
        {
           

            List<AuditBenchmark> listOfRpository = new List<AuditBenchmark>();

            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
                if(listOfRpository==null)
                {
                    return null;
                }
                else
                {
                    return listOfRpository;
                }*

            }
            catch (Exception)
            {
                return null;
            }

            /*if (listOfRpository==null)
            {
                return null;
            }
            else
            {
                return listOfRpository;
            }
*/




        
