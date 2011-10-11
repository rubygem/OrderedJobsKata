using System;
using System.Collections.Generic;

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
            List<Job> jobs = GetJobs(instructions);

            return Order(jobs);
        }

        private List<Job> GetJobs(string[] instructions)
        {
            var jobs = new List<Job>();
            foreach (var instruction in instructions)
            {
                jobs.Add(new Job(instruction));
            }
            return jobs;
        }

        private List<string> Order(List<Job> jobs)
        {
            var stringJobs = new List<string>();
            foreach (var job in jobs)
            {
                if (job.Dependency != null) stringJobs.Add(job.Dependency.Name);
                if (!stringJobs.Contains(job.Name)) stringJobs.Add(job.Name);
            }
            return stringJobs;
        }
    }
    
}