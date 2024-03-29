﻿using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OrderedJobs;

namespace Instructions.Tests
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

            String instructions = String.Join(Environment.NewLine, new[] {line1, line2, line3});

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
            String instructions = @"a =>
                                    b =>
                                    c =>";

            var mockSequence = new Mock<ISequence>();
            var sequence = new List<string> {"a", "b", "c"};
            mockSequence
                .Setup(x => x.GetSequence(It.IsAny<String[]>()))
                .Returns(sequence);

            Assert.That(new Instructions(instructions, mockSequence.Object).ComputeSequence(),
                        Is.EqualTo("abc"));
        }

        [Test]
        public void HandleSelfReferencingErrorWithFreindlyMessage()
        {
            Mock<ISequence> mockSequence = new Mock<ISequence>();
            mockSequence
                .Setup(x => x.GetSequence(It.IsAny<string[]>()))
                .Throws(new SelfReferencingException());
            var instructions = new Instructions("c =>c", mockSequence.Object);
            Assert.That(instructions.ComputeSequence(), Is.EqualTo("Error: jobs can't depend on themselves"));
        }
    }
}