using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.Job.Master.Entites.Map
{
    public class JobMap
    {
        #region 公开属性

        /// <summary>
        /// 自编号
        /// [default:0]
        /// </summary>
        public int WinServiceId { get; set; }
        /// <summary>
        /// 服务名称
        /// [default:string.Empty]
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// [enum]周期,DeductCycle:Once=0,Daily=1,Weekly=2,Fortnightly=3,Monthly=4,Yearly=5,-X=X分钟;
        /// [default:0]
        /// </summary>
        public int Cycle { get; set; }
        /// <summary>
        /// 下次运行时间
        /// [default:DBNull.Value]
        /// </summary>
        public DateTime? NextRunTime { get; set; }
        /// <summary>
        /// 状态:运行中重启 = -1,等待初始化 = 0,成功 = 1,失败 = 2,运行中 = 3,暂停 = 4
        /// [default:0]
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 运行失败时是否继续拨到下个时间: 不拨 = 0, 拨 = 1, 不拨且重试 = 2 (参考RetryInterval)
        /// [default:0]
        /// </summary>
        public int IsContinue { get; set; }
        /// <summary>
        /// [default:new DateTime()]
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 队列号 1:常规队列  2:小任务频繁执行队列  3:深圳定时任务队列
        /// [default:0]
        /// </summary>
        public int Queue { get; set; }
        /// <summary>
        /// 服务类型，格式：AssemblyName,TypeName 如:短信历史备份 SmsCenter.Facade,Winner.CU.SmsCenter.Facade.BackSmsHisFacade 
        /// [default:string.Empty]
        /// </summary>
        public string TypeConfig { get; set; }
        /// <summary>
        /// 备注。负责人
        /// [default:string.Empty]
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 下次重试时间，当ISCONTINUE = 2 时使用
        /// [default:DBNull.Value]
        /// </summary>
        public DateTime? RetryTime { get; set; }
        /// <summary>
        /// 重试间隔时间(分钟)，当ISCONTINUE = 2 时使用
        /// [default:0]
        /// </summary>
        public int RetryInterval { get; set; }
        /// <summary>
        /// 错误信息
        /// [default:string.Empty]
        /// </summary>
        public string ErrorInfo { get; set; }

        #endregion 公开属性
    }
}
