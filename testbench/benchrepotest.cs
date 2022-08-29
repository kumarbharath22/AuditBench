using AuditBenchmarkModule.Controllers;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace testbench
{
    public class benchrepotest
    {
        List<AuditBenchmark> l2 = new List<AuditBenchmark>();
        List<AuditBenchmark> l1 = new List<AuditBenchmark>();
        [SetUp]
        public void Setup()
        {

            l1 = new List<AuditBenchmark>()
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
          


        }

        
        [TestCase("Internal")]
        public void AuditBenchmark_validInput_ReturnBadRequest_Internal(string a)
        {
           
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist(a)).Returns(l1[0]);
            BenchmarkProvider cp = new BenchmarkProvider(mock.Object, new NullLogger<BenchmarkProvider>());
            AuditBenchmark result = cp.GetBenchmark(a) ;
    
            Assert.AreEqual(result.auditType, "Internal");

        }

        [TestCase("SOX")]
        public void AuditBenchmark_validInput_ReturnBadRequest_SOX(string a)
        {

            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist(a)).Returns(l1[1]);
            BenchmarkProvider cp = new BenchmarkProvider(mock.Object, new NullLogger<BenchmarkProvider>());
            AuditBenchmark result = cp.GetBenchmark(a);

            Assert.AreEqual(result.auditType, "SOX");

        }






    }
}
