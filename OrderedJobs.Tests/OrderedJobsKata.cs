using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class OrderedJobsKata
    {
        [Test]
        public void EmptyStringReturnsEmptySequence()
        {
            String result = new Sequence(String.Empty).Output();
            Assert.That(result, Is.EqualTo(""));
        }
    
        [Test]
        public void JobAReturnsA()
        {
            String result = new Sequence("a =>").Output();
            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void JobsABCReturnsABC()
        {
            var line1 = "a =>\n";
            var line2 = "b =>\n";
            var line3 = "c =>";

            String input = line1 + line2 + line3;

            String result = new Sequence(input).Output();

            Assert.That(result, Is.EqualTo("abc"));
        }
    }

    
}