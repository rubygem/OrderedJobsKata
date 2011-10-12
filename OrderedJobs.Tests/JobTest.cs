using Moq;
using NUnit.Framework;
using OrderedJobs;

namespace Instructions.Tests
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
            Assert.That(new Job("a=>b").Dependency.Name, Is.EqualTo("b"));
        }

        [Test]
        public void HasDependency()
        {
            Assert.That(new Job("a =>b").HasDependency, Is.True);
        }

        [Test]
        public void DoesNotHaveDependency()
        {
            Assert.That(new Job("a =>").HasDependency, Is.False);
        }

        [Test]
        public void SelfReferencingDependencyThrowsException()
        {
            try
            {
                new Job("c =>c");
                Assert.Fail("Expected Self Referencing Dependency Exception");
            }
            catch (SelfReferencingException)
            {
                Assert.Pass();
            }
        }
    }
}