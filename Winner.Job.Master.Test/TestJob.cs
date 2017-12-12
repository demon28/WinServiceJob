using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Job.Master.Interface;

namespace Winner.Job.Master.Test
{
    public class TestJob : IJob
    {
        public JobResult Run(DateTime runTime)
        {
            Log.Info("已经执行" + runTime.ToString());
            return JobResult.SuccessResult();
        }
    }
}
