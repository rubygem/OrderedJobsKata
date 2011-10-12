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
            String result = new Instructions(String.Empty).ComputeSequence();
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void StepTwoJobAReturnsA()
        {
            String result = new Instructions("a =>").ComputeSequence();
            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void StepThreeJobsABCReturnsABC()
        {
            var line1 = "a =>\n";
            var line2 = "b =>\n";
            var line3 = "c =>";

            String input = line1 + line2 + line3;

            String result = new Instructions(input).ComputeSequence();

            Assert.That(result, Is.EqualTo("abc"));
        }

        [Test]
        public void StepFourMultipleJobsSingleDependency()
        {
            var line1 = "a =>\n";
            var line2 = "b => c\n";
            var line3 = "c =>";

            String input = line1 + line2 + line3;

            String result = new Instructions(input).ComputeSequence();

            Assert.That(result, Is.EqualTo("acb"));
        }

        [Test]
        public void StepFiveMultipleJobsMultipleDependencies()
        {
            var instructions = new[]
                                   {
                                       "a =>", "b => c", "c => f", "d => a", "e => b", "f =>"
                                   };

            var input = String.Join("\n", instructions);

            String result = new Instructions(input).ComputeSequence();

            Assert.That(result, Is.EqualTo("afcbde"));
        }

        [Test]
        public void StepSixSelfReferencingDependency()
        {
            var instructions = new[] {"a =>", "b =>", "c => c"};

            var input = String.Join("\n", instructions);

            String result = new Instructions(input).ComputeSequence();

            Assert.That(result, Is.EqualTo("Error: jobs can't depend on themselves"));
        }

        [Test]
        public void StepSevenCircularDependencies()
        {
            var instructions = new[]
                                   {
                                       "a =>",
                                       "b => c",
                                       "c => f",
                                       "d => a",
                                       "e =>",
                                       "f => b"
                                   };

            var input = String.Join("\n", instructions);

            String result = new Instructions(input).ComputeSequence();

            Assert.That(result, Is.EqualTo("Error: circular dependency found"));
        }
    }
}