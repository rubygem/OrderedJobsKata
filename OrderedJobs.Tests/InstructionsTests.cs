using System;
using Moq;
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
            Assert.That(new Instructions().Split(instructions), Is.EqualTo(splitInstructions));
        }

        [Test]
        public void ComputeInstructionsGetsTheSequence()
        {
            var line1 = "a =>";
            var line2 = "b =>";
            var line3 = "c =>";

            String[] splitInstructions = new[] { line1, line2, line3 };
            
            String instructions = "a =>\nb =>\nc =>";

            var mockSequence = new Mock<Sequence>();
            var sequence = "abc";
            mockSequence
                .Setup(x => x.GetSequence(It.IsAny<String[]>()))
                .Returns(sequence);

            Assert.That(new Instructions(instructions, mockSequence.Object).ComputeSequence(), 
                Is.EqualTo(sequence));

            mockSequence.Verify(x => x.GetSequence(splitInstructions));
        }
    }

    public class Instructions
    {
        private readonly Sequence _sequence;
        private readonly String[] _instructions;

        public Instructions()
        {
        }

        public Instructions(string instructions, Sequence sequence)
        {
            _instructions = Split(instructions);
            _sequence = sequence;
        }

        public String[] Split(string instructions)
        {
            return instructions.Split('\n');
        }

        public String ComputeSequence()
        {
            return _sequence.GetSequence(_instructions);
        }
    }
}