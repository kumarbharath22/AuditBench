using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public interface IBenchmarkRepo
    {
       // Task<List<AuditBenchmark>> AuditBenchmarkListAsync();
        public AuditBenchmark GetNolist(string auditType);
       // public List<Questions> GetQuestions(string auditType);

    }
}
