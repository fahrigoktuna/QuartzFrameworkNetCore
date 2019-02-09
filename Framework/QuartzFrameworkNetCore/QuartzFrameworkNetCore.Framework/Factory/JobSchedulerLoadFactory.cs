using QuartzFrameworkNetCore.Framework.BaseJobScheduler;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace QuartzFrameworkNetCore.Framework.Factory
{
    public class JobSchedulerLoadFactory
    {
        private string AssembliesPath
        {
            get
            {
                return @"C:\QuartzFrameworkConcreteJobs";
            }
        }

        private List<string> LoadedAssembles { get; }

        public JobSchedulerLoadFactory(List<string> jobAssemblies)
        {
            LoadedAssembles = jobAssemblies;
        }

        public List<BaseScheduleJob> GetLoadedAssemblies()
        {
            List<BaseScheduleJob> jobList = new List<BaseScheduleJob>();
            LoadedAssembles.ForEach(_assembly =>
            {
                var _loggingAssembly = Assembly.LoadFrom(System.IO.Path.Combine(AssembliesPath, _assembly));
                jobList.Add (_loggingAssembly.CreateInstance(_loggingAssembly.GetExportedTypes()[0].FullName) as BaseScheduleJob);
            });
            return jobList;
        }
    }
}
