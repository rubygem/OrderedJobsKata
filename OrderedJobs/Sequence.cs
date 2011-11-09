using System;
using System.Collections.Generic;
using OrderedJobs;

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
            var dependencyList = new List<string>();
            foreach (var job in jobs)
            {
                if (job.HasDependency)
                {
                    if (dependencyList.Contains(job.DependencyName)) throw new CircularDependencyException();
                    dependencyList.Add(job.DependencyName);
                    jobNames = ReorderList(job, jobNames);
                }
            }
            return jobNames;
        }

        //public List<string> SortByDependencies(List<Job> jobs, List<string> jobNames)
        //{
        //    List<string> dependencyList = new List<string>();
        //    foreach (var job in jobs)
        //    {
        //        if (job.HasDependency)
        //        {
        //            if (dependencyList.Contains(job.DependencyName)) throw new 
        //            dependencyList.Add(job.DependencyName);
        //            jobNames = ReorderList(job, jobNames);
        //        }
        //    }
        //    return jobNames;
        //}

        private List<string> ReorderList(Job job, List<string> jobNames)
        {
            var positionOfJob = jobNames.IndexOf(job.Name);
            var positionOfDependency = jobNames.IndexOf(job.DependencyName);

            if (positionOfDependency > positionOfJob)
            {
                jobNames = MoveDependencyInFrontOfCurrentJob(job, jobNames, positionOfJob);
            }
            return jobNames;
        }

        private List<string> MoveDependencyInFrontOfCurrentJob(Job job, List<string> jobNames, int positionOfJob)
        {
            jobNames.Remove(job.DependencyName);
            jobNames.Insert(positionOfJob, job.DependencyName);
            return jobNames;
        }

        private List<string> AddJobs(List<Job> jobs, List<string> jobNames)
        {
            foreach (var job in jobs)
            {
                var jobName = job.Name;
                
                jobNames.Add(jobName);
            }

            return jobNames;
        }
    }

    public class CircularDependencyException : Exception
    {
    }
}