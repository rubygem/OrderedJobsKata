using System;
using System.Collections.Generic;
using OrderedJobs;

namespace Instructions
{
    public class Sequence : ISequence
    {
        public String GetSequence(string[] instructions)
        {
            return String.Join("", CreateListOfJobNames(instructions));
        }

        private List<String> CreateListOfJobNames(string[] instructions)
        {
            List<Job> jobs = new List<Job>();
            foreach (var instruction in instructions)
            {
                jobs.Add(new Job(instruction));
            }

            return new Jobs().Order(jobs);
        }
    }
    
}