using System;

namespace OrderedJobs.Tests
{
    public class Sequence
    {
        private string _resultingSequence;

        public Sequence(string instruction)
        {
            var job = new Job().ParseJob(instruction);
            
            _resultingSequence = job;
        }
        
        public String Output()
        {
            return _resultingSequence;
        }
    }

    public class Job
    {
        public string ParseJob(String input)
        {
            var job = String.Empty;
            if (!String.IsNullOrEmpty(input)) job = input[0].ToString();
            return job;
        }
    }
}