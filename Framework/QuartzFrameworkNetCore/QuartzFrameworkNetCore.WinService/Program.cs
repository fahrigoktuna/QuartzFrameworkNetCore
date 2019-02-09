using QuartzFrameworkNetCore.Framework;
using QuartzFrameworkNetCore.Framework.Factory;
using System;
using System.Collections.Generic;

namespace QuartzFrameworkNetCore.WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            //these assemblies can be loaded dynamically from db or any data source
            var assemblyList = new List<string>() { "QuartzFrameworkNetCore.ConcreteJob1Service.dll", "QuartzFrameworkNetCore.ConcreteJob2Service.dll" };

            var jobs = new JobSchedulerLoadFactory(assemblyList).GetLoadedAssemblies();

            JobScheduler.Start(jobs);

            Console.Read();
        }
    }
}
