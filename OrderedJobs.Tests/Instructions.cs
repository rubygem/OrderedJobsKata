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
            _instructions = List(instructions);
            _sequence = sequence;
        }

        public Instructions()
        {
        }

        public String[] List(string instructions)
        {
            var emptyListOfInstructions = new string[0];
            var listOfInstructions = Split(instructions);
            return String.IsNullOrEmpty(instructions) ? emptyListOfInstructions : listOfInstructions;
        }

        private string[] Split(string instructions)
        {
            return instructions.Split('\n');
        }

        public String ComputeSequence()
        {
            return _sequence.GetSequence(_instructions);
        }
    }
}