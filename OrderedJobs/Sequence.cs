using System;
using System.Collections.Generic;

namespace OrderedJobs
{
    public class Sequence : ISequence
    {
        public String GetSequence(string[] instructions)
        {
            return String.Join("", OrderedListOfJobs(instructions));
        }

        private String[] OrderedListOfJobs(string[] instructions)
        {
            List<Job> jobs = CreateListOfOrderedJobs(instructions);

            List<string> orderedJobs = GetOrderedJobs(jobs);

            return orderedJobs.ToArray();
        }

        private List<string> GetOrderedJobs(List<Job> jobs)
        {
            var orderedJobs = new List<String>();
            foreach (var job in jobs)
            {
                orderedJobs.Add(job.JobName);
            }
            return orderedJobs;
        }

        private List<Job> CreateListOfOrderedJobs(string[] instructions)
        {
            var jobs = new List<Job>();
            foreach (var instruction in instructions)
            {
                jobs.Add(new Job(instruction));
            }
            return jobs;
        }
    }
    
}