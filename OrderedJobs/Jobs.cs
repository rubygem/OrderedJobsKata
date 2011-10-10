using System.Collections.Generic;
using Instructions;

namespace OrderedJobs
{
    public class Jobs
    {
        public List<string> Order(List<Job> jobs)
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