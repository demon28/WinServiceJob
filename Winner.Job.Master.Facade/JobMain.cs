using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Job.Master.Entites;
using Winner.Job.Master.Interface;

namespace Winner.Job.Master.Facade
{
    /// <summary>
    /// 执行 工作计划 入口
    /// </summary>
    public class JobMain : IJobMain
    {

        public void Start()
        {
            Log.Info("任务计划已启动......");

            //服务列队
            int serviceQueue = ConfigProvider.GetAppSetting<int>("Winner.Job.Master.Queue", 0);

            //初始化，获取列队服务
            Log.Info("初始化任务计划列队中......");
            try
            {
                JobQueue.Instance.Init(serviceQueue);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //throw ex;
            }
            Log.Info(string.Format("已加载{0}列队共有{1}个服务", serviceQueue, JobQueue.Instance.Jobs.Count));
            while (true)
            {
                var services = JobQueue.Instance.Jobs;
                //线程集合
                List<Task> tasks = new List<Task>();
                foreach (var job in services)
                {
                    if (job.Status == (int)JobStatus.暂停
                        || (job.NextRunTime.HasValue && job.NextRunTime.Value > DateTime.Now))
                        continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        //执行服务
                        Log.Info("开始执行：Service = " + job.ServiceName);
                        JobService jobServcie = new JobService();
                        jobServcie.Execute(job);
                        Log.Info("执行完毕：Service = " + job.ServiceName);
                    }));

                }
                //线程同步
                Log.Info("同步任务计划线程中......");
                Task.WaitAll(tasks.ToArray());
                //TODO:根据最近需要执行的任务计算出时间，然后进行定时处理
                var lateTime = services.Min(s => s.NextRunTime.Value - DateTime.Now);
                if (lateTime.TotalMilliseconds < 0)
                {
                    continue;
                }
                //间隔30秒
                Log.Info("任务计划休眠" + lateTime.TotalMinutes + "分钟......");
                System.Threading.Thread.Sleep(lateTime);
            }
        }
    }
}
