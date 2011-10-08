using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Instructions.Tests
{
    [TestFixture]
    public class OrderedJobsTests
    {
        [Test]
        public void OrderJobs()
        {
            var jobs = new List<Job>();
            jobs.Add(new Job("a => b"));
            jobs.Add(new Job("b =>"));

            var actualOrderedJobs = new Jobs(); 

            var expectedJobs = new List<string>();
                
            Assert.That(actualOrderedJobs.Order(jobs), Is.EqualTo(expectedJobs));
        }
    }

    public class Jobs
    {
        public TestDelegate Order(List<Job> jobs)
        {
            throw new NotImplementedException();
        }
    }
}