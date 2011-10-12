using System;
using System.Collections.Generic;

namespace Instructions
{
    public class Sequence : ISequence
    {
        public List<String> GetSequence(string[] instructions)
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
            var jobNames = new List<string>();
            jobNames = AddJobs(jobs, jobNames);
            jobNames = SortByDependencies(jobs, jobNames);
            
            return jobNames;
        }

        public List<string> SortByDependencies(List<Job> jobs, List<string> jobNames)
        {
            throw new NotImplementedException();
        }

        private List<string> AddJobs(List<Job> jobs, List<string> jobNames)
        {
            foreach (var job in jobs)
            {
                var jobName = job.Name;
                if (!jobNames.Contains(jobName)) jobNames.Add(jobName);
            }

            return jobNames;
        }
    }
    
}