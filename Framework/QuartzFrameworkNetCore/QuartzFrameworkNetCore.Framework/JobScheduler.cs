using Quartz;
using Quartz.Impl;
using QuartzFrameworkNetCore.Framework.BaseJobScheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzFrameworkNetCore.Framework
{
    public class JobScheduler
    {
        public static async void Start(List<BaseScheduleJob> jobList)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            jobList.ForEach(_job =>
            {
                var activatedJob = (BaseScheduleJob)Activator.CreateInstance(_job.GetType());

                IJobDetail job = JobBuilder.Create(activatedJob.GetType()).Build();

                ITrigger trigger = TriggerBuilder.Create()

                                     .WithIdentity(_job.GetType().Name, _job.JobGroupName)

                                     .WithCronSchedule(_job.JobCronExpression)

                                     .StartAt(DateTime.UtcNow)

                                     .WithPriority(_job.JobWithPriority)

                                     .Build();

                scheduler.ScheduleJob(job, trigger);
            });
        }

    }
}
