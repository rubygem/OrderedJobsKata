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
            Assert.That(sequence.GetSequence(new[] { "a =>" }), Is.EqualTo(new List<string> {"a"}));
        }

        [Test]
        public void TwoLineInputReturnsTwoJobs()
        {
            var sequence = new Sequence();
            Assert.That(sequence.GetSequence(new[] { "a =>", "b =>" }), Is.EqualTo(new List<string> { "a", "b" }));
        }

        [Test]
        public void TwoLineInputWithDependencyReturnsTwoJobs()
        {
            var sequence = new Sequence();
            Assert.That(sequence.GetSequence(new[] { "a =>b", "b =>" }), Is.EqualTo(new List<string> { "b","a" }));
        }

        [Test]
        public void ThreeLinesWithDependenciesReturnsThreeJobsInOrder()
        {
            var sequence = new Sequence();
            Assert.That(sequence.GetSequence(new[] { "a =>c", "b =>", "c =>b" }), Is.EqualTo(new List<string> { "b", "c", "a" }));
        }

        [Test]
        public void SortByDependencies()
        {
            var orderedJobNames = new List<string> {"b", "c", "a"};
            Assert.That(new Sequence().SortByDependencies(jobs, jobNames), Is.EqualTo(orderedJobNames));
        }
    }
}