using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void EmptyInputReturnsEmptySequence()
        {
            Assert.That(new Sequence(String.Empty).Output(), Is.EqualTo(String.Empty));
        }

    }
}