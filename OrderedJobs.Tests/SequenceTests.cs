﻿using System.Collections.Generic;
﻿using Instructions;
﻿using Moq;
﻿using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void SingleLineInputReturnsSingleJob()
        {
            var sequence = new Sequence();
            Assert.That(sequence.GetSequence(new[] { "a =>" }), Is.EqualTo("a"));
        }

        [Test]
        public void TwoLineInputReturnsTwoJobs()
        {
            var sequence = new Sequence();
            Assert.That(sequence.GetSequence(new[] { "a =>", "b =>" }), Is.EqualTo("ab"));
        }

        [Test]
        public void TwoLineInputWithDependencyReturnsTwoJobs()
        {
            var sequence = new Sequence();
            Assert.That(sequence.GetSequence(new[] { "a =>b", "b =>" }), Is.EqualTo("ba"));
        }
    }
}