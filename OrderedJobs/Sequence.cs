using System;
using System.Collections.Generic;

namespace OrderedJobs
{
    public class Sequence : ISequence
    {
        public String GetSequence(string[] instructions)
        {
            return String.Join("", CreateListOfJobNames(instructions));
        }

        private List<String> CreateListOfJobNames(string[] instructions)
        {
            var jobs = new List<String>();
            foreach (var instruction in instructions)
            {
                jobs.Add(new Job(instruction).JobName);
            }
            return jobs;
        }
    }
    
}