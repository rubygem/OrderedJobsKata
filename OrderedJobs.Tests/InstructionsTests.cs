﻿using System;
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
            Assert.That(new Instructions().List(instructions), Is.EqualTo(splitInstructions));
        }

        [Test]
        public void EmptyInstructions()
        {
            Assert.That(new Instructions().List(String.Empty), Is.EqualTo(new String[0]));
        }

        [Test]
        public void ComputeInstructionsGetsTheSequence()
        {
            var line1 = "a =>";
            var line2 = "b =>";
            var line3 = "c =>";

            String[] splitInstructions = new[] { line1, line2, line3 };
            
            String instructions = "a =>\nb =>\nc =>";

            var mockSequence = new Mock<ISequence>();
            var sequence = "abc";
            mockSequence
                .Setup(x => x.GetSequence(It.IsAny<String[]>()))
                .Returns(sequence);

            Assert.That(new Instructions(instructions, mockSequence.Object).ComputeSequence(), 
                Is.EqualTo(sequence));

            mockSequence.Verify(x => x.GetSequence(splitInstructions));
        }
    }
}