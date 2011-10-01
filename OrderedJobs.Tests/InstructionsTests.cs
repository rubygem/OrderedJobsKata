using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class InstructionsTests
    {
        [Test]
        public void SplitInstructionsIntoListOfLines()
        {
            var line1 = "a =>";
            var line2 = "b =>";
            var line3 = "c =>";

            String instructions = "a =>\nb =>\nc =>";

            String[] splitInstructions = new[] {line1, line2, line3};
            Assert.That(new Instructions(instructions).Split(), Is.EqualTo(splitInstructions));
        }
    }

    public class Instructions
    {
        private readonly string _instructions;

        public Instructions(string instructions)
        {
            _instructions = instructions;
        }

        public String[] Split()
        {
            return _instructions.Split('\n');
        }
    }
}