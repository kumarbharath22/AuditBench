using AuditBenchmarkModule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Data
{
    public class BenchmarkContext:DbContext
    {
        public BenchmarkContext(DbContextOptions<BenchmarkContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            {
                builder.Entity<AuditBenchmark>().HasData(
                new AuditBenchmark
                {
                    auditType = "Internal",
                    benchmarkNoAnswers = 3
                },
                new AuditBenchmark
                {

                    auditType = "SOX",
                    benchmarkNoAnswers = 1

                },
                new AuditBenchmark
                {

                    auditType = "Unknown",
                    benchmarkNoAnswers = 4

                }

                );
            }
        }

        public DbSet<AuditBenchmark> BenchmarkLists { get; set; }
    }
}
