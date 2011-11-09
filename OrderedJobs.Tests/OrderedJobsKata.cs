using System;
using NUnit.Framework;

namespace Instructions.Tests
{
    [TestFixture]
    public class OrderedJobsKata
    {
        [Test]
        public void StepOneEmptyStringReturnsEmptySequence()
        {
            Assert.That(new Instructions(String.Empty).ComputeSequence(), Is.EqualTo(""));
        }

        [Test]
        public void StepTwoJobAReturnsA()
        {
            Assert.That(new Instructions("a =>").ComputeSequence(), Is.EqualTo("a"));
        }

        [Test]
        public void StepThreeJobsABCReturnsABC()
        {
            var line1 = @"a =>
                        b =>
                        c =>";

            String result = new Instructions(line1).ComputeSequence();

            Assert.That(result, Is.EqualTo("abc"));
        }

        [Test]
        public void StepFourMultipleJobsSingleDependency()
        {
            var line1 = @"a =>
                        b => c
                        c =>";

            String result = new Instructions(line1).ComputeSequence();

            Assert.That(result, Is.EqualTo("acb"));
        }

        [Test]
        public void StepFiveMultipleJobsMultipleDependencies()
        {
            var instructions =
                @"a =>
                                b => c
                                c => f
                                d => a
                                e => b
                                f =>";

            String result = new Instructions(instructions).ComputeSequence();

            Assert.That(result, Is.EqualTo("afcbde"));
        }

        [Test]
        public void StepSixSelfReferencingDependency()
        {
            var instructions = @"a =>
                                b =>
                                c => c";

            String result = new Instructions(instructions).ComputeSequence();

            Assert.That(result, Is.EqualTo("Error: jobs can't depend on themselves"));
        }

        [Test]
        public void StepSevenCircularDependencies()
        {
            var instructions = @"a =>
                               b => c
                               c => f
                               d => a
                               e =>
                               f => b";

            String result = new Instructions(instructions).ComputeSequence();

            Assert.That(result, Is.EqualTo("Error: circular dependency found"));
        }
    }
}