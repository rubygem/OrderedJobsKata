using System;
using System.Collections.Generic;

namespace OrderedJobs.Tests
{
    public class Sequence
    {
        private string _resultingSequence;

        public Sequence(string instructions)
        {
            var jobList = new List<String>();
            foreach (var instruction in instructions.Split('\n'))
            {
                jobList.Add(new Job(instruction).JobName);
            }
            _resultingSequence = String.Join("", jobList);
        }
        
        public String Output()
        {
            return _resultingSequence;
        }
    }

    public class Job
    {
        public Job(string instruction)
        {
            ParseName(instruction);
        }

        public string JobName { get; private set; }

        private void ParseName(String input)
        {
            try
            {
                JobName = input[0].ToString();
            }
            catch (Exception)
            {
                JobName = String.Empty;
            }
        }
    }
}