using System;

namespace OrderedJobs.Tests
{
    public class Instructions
    {
        private readonly Sequence _sequence;
        private readonly String[] _instructions;

        public Instructions(string instructions)
            : this (instructions, new SequenceImp())
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