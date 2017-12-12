using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.Job.Master.Interface
{
    /// <summary>
    /// WinService工作单元接口
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// 执行工作单元
        /// </summary>
        /// <param name="runTime"></param>
        /// <returns>返回执行结果JobResult</returns>
        JobResult Run(DateTime runTime);
    }
}
