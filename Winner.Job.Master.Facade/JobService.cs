using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Job.Master.DataAccess;
using Winner.Job.Master.Entites;
using Winner.Job.Master.Entites.Map;
using Winner.Job.Master.Interface;
using Winner.Job.Master.Remoting;

namespace Winner.Job.Master.Facade
{
    /// <summary>
    /// 工作计划服务对象
    /// </summary>
    [Serializable]
    public class JobService
    {
        public void Execute(JobMap job)
        {
            try
            {
                //远程执行服务
                var result = RemoteExecute(job);
                if (!result.Success)
                {
                    job.Status = (int)JobStatus.失败;
                    job.ErrorInfo = result.Message;
                }
                else
                {
                    job.Status = (int)JobStatus.成功;
                    job.ErrorInfo = string.Empty;
                }

                //计算状态和下次运行情况
                ModifyModel(job);

                //修改数据库时间
                Modify(job);

                //GC回收
                GC.Collect();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 远程执行
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        private JobResult RemoteExecute(JobMap job)
        {
            AppDomain appDomain = null;
            try
            {
                //服务反射信息
                string[] array = job.TypeConfig.Split(',');
                //服务的程序集名称
                string assemblyFile = array[0];
                //服务的类名称
                string className = array[1];

                //设置AppDomain安装程序信息
                AppDomainSetup setup = new AppDomainSetup();

                //服务名称
                setup.ApplicationName = job.ServiceName;
                //安装（运行）目录（提示：在当前运行目录的子目录，而子目录则是”服务名称“）
                setup.ApplicationBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, job.ServiceName);
                setup.ShadowCopyDirectories = setup.ApplicationBase;
                setup.ShadowCopyFiles = "true";
                //Config配置文件路径
                setup.ConfigurationFile = Path.Combine(setup.ApplicationBase, assemblyFile + ".dll.config");

                //构造一个新的AppDomain
                appDomain = AppDomain.CreateDomain(job.ServiceName, null, setup);
                //获取远程调用程序 对象名称
                string name = Assembly.LoadFile(Path.Combine(setup.ApplicationBase, "Winner.Job.Master.Remoting.dll")).GetName().FullName;

                //创建远程调用程序实例
                var remoteLoader = (RemoteLoader)appDomain.CreateInstanceAndUnwrap(name, typeof(RemoteLoader).FullName);

                //加载服务程序集
                remoteLoader.LoadAssembly(Path.Combine(setup.ApplicationBase, assemblyFile + ".dll"));

                //执行服务
                var result = remoteLoader.ExecuteMothod(className, job.NextRunTime);
                Log.Info(string.Format("执行结果：Service={0} Success={1} Message={2}", job.ServiceName, result.Success, result.Message));
                return result;

            }
            catch (Exception ex)
            {
                Log.Error("执行服务异常", ex);
                return JobResult.FailResult("远程执行服务出现异常：" + ex.Message); ;
            }
            finally
            {
                if (appDomain != null)
                {
                    Log.Info("卸载AppDomain：" + appDomain.FriendlyName);
                    AppDomain.Unload(appDomain);
                    appDomain = null;
                }
            }
        }

        private void ModifyModel(JobMap job)
        {
            if (job == null)
                return;
            if (job.Status != (int)JobStatus.暂停 && job.Status != (int)JobStatus.成功 && job.IsContinue == 2)
            {
                job.RetryTime = DateTime.Now.AddMinutes(job.RetryInterval);
                return;
            }
            if (job.IsContinue == 1 || job.Status == (int)JobStatus.成功)
            {
                job.NextRunTime = job.NextRunTime.HasValue ? job.NextRunTime.Value : DateTime.Now;
                if (job.Cycle != 0)
                {
                    if (job.Cycle < 0)
                        job.NextRunTime = job.NextRunTime.HasValue ? job.NextRunTime.Value.AddMinutes(0 - job.Cycle) : DateTime.Now.AddMinutes(0 - job.Cycle);
                    else
                    {
                        switch ((Cycle)job.Cycle)
                        {
                            case Cycle.Daily: job.NextRunTime = job.NextRunTime.Value.AddDays(1); break;
                            case Cycle.Fortnightly: job.NextRunTime = job.NextRunTime.Value.AddDays(14); break;
                            case Cycle.Monthly: job.NextRunTime = job.NextRunTime.Value.AddMonths(1); break;
                            case Cycle.Weekly: job.NextRunTime = job.NextRunTime.Value.AddDays(7); break;
                            case Cycle.Yearly: job.NextRunTime = job.NextRunTime.Value.AddYears(1); break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private bool Modify(JobMap job)
        {
            Tsys_Winservice daWinService = new Tsys_Winservice();
            daWinService.WinServiceId = job.WinServiceId;
            daWinService.NextRunTime = job.NextRunTime;
            daWinService.Status = job.Status;
            daWinService.RetryTime = job.RetryTime;
            daWinService.RetryInterval = job.RetryInterval;
            if (!daWinService.Update())
            {
                return false;
            }
            return true;
        }
    }
}
