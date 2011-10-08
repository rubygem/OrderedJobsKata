using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class JobTest
    {
        [Test]
        public void InstructionReturnsJob()
        {
            Assert.That(new Job("a=>").JobName, Is.EqualTo("a"));
        }

    }
}