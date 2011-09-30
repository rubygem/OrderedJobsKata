using System;

namespace OrderedJobs.Tests
{
    public class Sequence
    {
        private string _resultingSequence;

        public Sequence(string instruction)
        {
            string job;
            if (String.IsNullOrEmpty(instruction)) job = String.Empty;
            else job = new Job().ParseJob(instruction);
            
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
            return input[0].ToString();
        }
    }
}