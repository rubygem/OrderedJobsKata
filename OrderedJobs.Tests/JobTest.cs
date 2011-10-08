using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class JobTest
    {
        [Test]
        public void InstructionReturnsJobName()
        {
            Assert.That(new Job("a=>").Name, Is.EqualTo("a"));
        }

        [Test]
        public void InstructionReturnsJobDependency()
        {
            Assert.That(new Job("a=>").Dependency, Is.Null);
        }

        [Test]
        public void InstructionReturnsJobItDependsOn()
        {
            Assert.That(new Job("a=>b").Dependency, Is.EqualTo(new Job("b=>")));
        }
    }
}