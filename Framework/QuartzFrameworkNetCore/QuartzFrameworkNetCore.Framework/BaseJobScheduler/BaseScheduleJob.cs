using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartzFrameworkNetCore.Framework.BaseJobScheduler
{
    public abstract class BaseScheduleJob : IJob
    {
        void StartingJob(IJobExecutionContext context)
        {
            Console.WriteLine(context.JobInstance + " is started by JobScheduler");
        }

        void EndingJob(IJobExecutionContext context)
        {
            Console.WriteLine($"{context.JobInstance}  is ended by JobScheduler nextCallTime is {context.NextFireTimeUtc.Value.ToLocalTime().ToString("dd / MM / yyyy HH: mm: ss")}");
        }

        public abstract Task RunYourJob();
        public abstract string JobGroupName { get; }
        public abstract string JobCronExpression { get; }
        public abstract int JobWithPriority { get; }

        public Task Execute(IJobExecutionContext context)
        {
            StartingJob(context);
            Task task = RunYourJob();
            EndingJob(context);
            return task;
        }
    }

}
