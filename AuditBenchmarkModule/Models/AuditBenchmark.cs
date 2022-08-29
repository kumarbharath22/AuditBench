using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Models
{
    
    public class AuditBenchmark
    {
        [Key]
        public string auditType { get; set; }
        public int benchmarkNoAnswers { get; set; }
    }
}
