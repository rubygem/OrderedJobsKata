using System;
using NUnit.Framework;
namespace OrderedJobs.Tests
{
    [TestFixture]
    public class TakeEmptyStrings
    {
        [Test]
        public void EmptyStringReturnsEmptySequence()
        {
            String input = "";
            String result = input;
            Assert.That(result, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class TakeSingleJob
    {
        [Test]
        public void JobAReturnsA()
        {
            String input = "a =>";
            String result = input[0].ToString();
            Assert.That(result, Is.EqualTo("a"));
        }
    }
}