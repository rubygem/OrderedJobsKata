using System;

namespace OrderedJobs
{
    public class Job
    {
        public Job(string instruction)
        {
            _instruction = instruction.Split(new[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);
            if (HasDependency && DependencyName == Name) throw new SelfReferencingException();

        }

        private readonly string[] _instruction;

        public string Name
        {
            get { return _instruction[0].Trim(); }
        }

        public string DependencyName
        {
            get
            {
                string dependency = null;
                if (_instruction.Length > 1)
                {
                    dependency = _instruction[1].Trim();
                }
                return dependency;    
            }
        }

        public bool HasDependency
        {
            get { return DependencyName != null; }
        }
    }

    public class SelfReferencingException : Exception
    {
    }
}