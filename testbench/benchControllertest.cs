using AuditBenchmarkModule.Controllers;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace testbench
{
    public class TestsController
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
            l2 = new List<AuditBenchmark>()
                {
                    new AuditBenchmark
                    {
                        auditType="ABC",
                        benchmarkNoAnswers=4
                    }
                };


        }


        [TestCase("Internal")]
        public void AuditBenchmark_ValidInput_OkRequest_Internal(string a)
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark(a)).Returns(l1[0]);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
            OkObjectResult result = cp.GetAuditBenchmark(a) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestCase("SOX")]
        public void AuditBenchmark_ValidInput_OkRequest_SOX(string a)
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark(a)).Returns(l1[1]);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
            OkObjectResult result = cp.GetAuditBenchmark(a) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }



        [TestCase("ABC")]
        public void AuditBenchmark_InvalidInput_ReturnBadRequest_Unknown(string a)
        {
            try
            {
                Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
                mock.Setup(p => p.GetBenchmark(a)).Returns(l2[0]);
                AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
                var result = cp.GetAuditBenchmark(a) as BadRequestResult;
                Assert.AreEqual(400, result.StatusCode);
            }

            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }
    }
}

      

