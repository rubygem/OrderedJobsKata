using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void SingleLineInputReturnsSingleJob()
        {
            Assert.That(new SequenceImp("a =>").Output(), Is.EqualTo("a"));
        }
    }
}