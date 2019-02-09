using QuartzFrameworkNetCore.Framework.BaseJobScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QuartzFrameworkNetCore.ConcreteJobs
{
    public class ConcreteJob2 : BaseScheduleJob
    {
        public override string JobGroupName => "FileWriter";

        public override string JobCronExpression => "0/10 * * * * ?";

        public override int JobWithPriority => 1;

        public override Task RunYourJob()
        {
            using (StreamWriter streamWriter = new StreamWriter(@"C:\ConcreteJob2.txt", true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString());
            }

            return Task.CompletedTask;
        }
    }
}
