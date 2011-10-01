using System;
using System.Collections.Generic;

namespace OrderedJobs.Tests
{
    public class SequenceImp
    {
        private string _resultingSequence;

        public SequenceImp(string instructions)
        {
            var jobList = new List<String>();
            foreach (var instruction in SplitInstructions(instructions))
            {
                if(instruction.Length > 1) jobList.Add(instruction[0].ToString());
            }
            _resultingSequence = String.Join("", jobList);
        }

        private string[] SplitInstructions(string instructions)
        {
            return instructions.Split('\n');
        }

        public String Output()
        {
            return _resultingSequence;
        }
    }
    
}