using System;
using System.Collections.Generic;
using OrderedJobs;

namespace Instructions
{
    public class Instructions
    {
        private readonly ISequence _sequence;
        private readonly String[] _instructions;

        public Instructions(string instructions)
            : this (instructions, new Sequence())
        {
        }

        public Instructions(string instructions, ISequence sequence)
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
            return instructions.Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
        }

        public String ComputeSequence()
        {
            List<string> sequence;
            try
            {
                sequence = _sequence.GetSequence(_instructions);
            }
            catch (SelfReferencingException)
            {
                return "Error: jobs can't depend on themselves";
            }
            catch(CircularDependencyException)
            {
                return "Error: circular dependency found";
            }
            return String.Join("", sequence);
        }
    }
}