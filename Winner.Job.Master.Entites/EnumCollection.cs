using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.Job.Master.Entites
{
    public enum Cycle
    {
        /// <summary>
        /// 仅一次
        /// </summary>
        Once = 0,
        /// <summary>
        /// 每日
        /// </summary>
        Daily = 1,
        /// <summary>
        /// 每周
        /// </summary>
        Weekly = 2,
        /// <summary>
        /// 每两周
        /// </summary>
        Fortnightly = 3,
        /// <summary>
        /// 每月
        /// </summary>
        Monthly = 4,
        /// <summary>
        /// 每年
        /// </summary>
        Yearly = 5
    }

    public enum JobStatus
    {
        运行中重启 = -1,
        等待初始化 = 0,
        成功 = 1,
        失败 = 2,
        运行中 = 3,
        暂停 = 4
    }
}
