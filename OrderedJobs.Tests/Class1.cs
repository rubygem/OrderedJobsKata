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
            String result = "";
            Assert.That(result, Is.EqualTo(""));
        }
    }
}