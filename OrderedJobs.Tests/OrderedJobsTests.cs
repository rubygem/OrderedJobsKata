using System.Collections.Generic;
using NUnit.Framework;
using OrderedJobs;

namespace Instructions.Tests
{
    [TestFixture]
    public class DependentOrderedJobsTests
    {
        private List<string> _expectedJobs;
        private Jobs _actualOrderedJobs;
        private List<Job> _jobs;

        [SetUp]
        public void SetUp()
        {
            _jobs = new List<Job>();
            _jobs.Add(new Job("a => b"));
            _jobs.Add(new Job("b =>"));

            _actualOrderedJobs = new Jobs();

            _expectedJobs = new List<string> { "b", "a" };
        }

        [Test]
        public void TwoJobs()
        {
            Assert.That(_actualOrderedJobs.Order(_jobs).Count, Is.EqualTo(2));
        }

        [Test]
        public void JobsInRightOrder()
        {
            Assert.That(_actualOrderedJobs.Order(_jobs), Is.EqualTo(_expectedJobs));
        }
    }

    [TestFixture]
    public class OrderJobsTests
    {
        private List<string> _expectedJobs;
        private Jobs _actualOrderedJobs;
        private List<Job> _jobs;

        [SetUp]
        public void SetUp()
        {
            _jobs = new List<Job> {new Job("a =>"), new Job("b =>")};

            _actualOrderedJobs = new Jobs();

            _expectedJobs = new List<string> { "a", "b" };
        }

        [Test]
        public void JobsInRightOrder()
        {
            Assert.That(_actualOrderedJobs.Order(_jobs), Is.EqualTo(_expectedJobs));
        }
    }
}