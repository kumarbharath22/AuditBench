using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Repository;
using AuditBenchmarkModule.Providers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using AuditBenchmarkModule.Controllers;

namespace testbench
{
    public class benchProviderTest
    {
        List<AuditBenchmark> AuditBenchmarkList1 = new List<AuditBenchmark>();
        List<AuditBenchmark> AuditBenchmarkList2 = new List<AuditBenchmark>();
        [SetUp]
        public void Setup()
        {
            AuditBenchmarkList1 = new List<AuditBenchmark>()
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
            AuditBenchmarkList2 = new List<AuditBenchmark>()
            {
                new AuditBenchmark
                {
                    auditType="ABC",
                    benchmarkNoAnswers=4
                }
            };
           





        }


        [TestCase("Internal")]
        public void GetBenchmark_ValidInput_OkRequest_Internal(string a)
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark(a)).Returns(AuditBenchmarkList1[0]);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
            OkObjectResult? result = cp.GetAuditBenchmark(a) as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200)); 
          
        }

        [TestCase("SOX")]
        public void GetBenchmark_ValidInput_OkRequest_SOX(string a)
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark(a)).Returns(AuditBenchmarkList1[1]);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
            OkObjectResult? result = cp.GetAuditBenchmark(a) as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }

        [TestCase("ABC")]
        public void AuditBenchmark_InvalidInput_ReturnBadRequest_Unknown(string a)
        {
            try
            {
                Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
                mock.Setup(p => p.GetBenchmark(a)).Returns(AuditBenchmarkList2[0]);
                AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
                var result = cp.GetAuditBenchmark(a) as BadRequestResult;
                Assert.AreEqual(400, result.StatusCode);
            }

            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }


        /*[TestCase("ABC")]
        public void GetBenchmark_ValidInput_OkRequest_Unknown(string a)
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark(a)).Returns(AuditBenchmarkList2[1]);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object, new NullLogger<AuditBenchmarkController>());
            OkObjectResult? result = cp.GetAuditBenchmark(a) as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }*/
    }
}
