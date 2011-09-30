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
            Assert.That(new Sequence().Output(String.Empty), Is.EqualTo(String.Empty));
        }

    }
}