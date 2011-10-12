using System;

namespace OrderedJobs
{
    public class Job
    {
        public Job(string instruction)
        {
            _instruction = instruction.Split(new[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);
            if (HasDependency && Dependency.Name == Name) throw new SelfReferencingException();

        }

        private readonly string[] _instruction;

        public string Name
        {
            get { return _instruction[0].Trim(); }
        }

        public Job Dependency
        {
            get
            {
                Job dependency = null;
                if (_instruction.Length > 1)
                {
                    dependency = new Job(_instruction[1].Trim());
                }
                return dependency;    
            }
        }

        public bool HasDependency
        {
            get { return Dependency != null; }
        }
    }
}