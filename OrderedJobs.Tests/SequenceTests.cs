﻿using Instructions;
﻿using Moq;
﻿using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        private Sequence _sequence = new Sequence();
        
        [Test]
        public void SingleLineInputReturnsSingleJob()
        {
            Assert.That(_sequence.GetSequence(new[] { "a =>" }), Is.EqualTo("a"));
        }

        [Test]
        public void TwoLineInputReturnsTwoJobs()
        {
            Assert.That(_sequence.GetSequence(new[] { "a =>", "b =>" }), Is.EqualTo("ab"));
        }

        [Test]
        public void TwoLineInputWithDependencyReturnsTwoJobs()
        {
            Assert.That(_sequence.GetSequence(new[] { "a =>b", "b =>" }), Is.EqualTo("ba"));
        }
    }
}